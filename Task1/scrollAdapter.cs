using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scrollAdapter : MonoBehaviour
{
    private bool loading = false;

    [SerializeField] 
    private int curImage = 0;
    [SerializeField]
    private int countImages;

    [SerializeField]
    private Scrollbar scrollbar;
    [SerializeField]
    private RectTransform prefab;
    [SerializeField]
    private RectTransform content;

    [SerializeField] 
    private string url;

    private void Start() {
        updateItems();
    }
    private void Update() {
        if(scrollbar.value <= 0.1f && !loading){
            loading = true;

            StartCoroutine(loadNewImage());
        }
    }
    private IEnumerator loadNewImage(){
        countImages+=4;

        if(countImages <= 70){
            updateItems();
            yield return new WaitForSeconds(1f);
        }

        loading = false;
    }

    public void updateItems(){
        itemModel[] models = new itemModel[countImages];

        for(int i = curImage; i<countImages; i++){
            if(i > 66){
                countImages = 66;
                break;
            }
            models[i] = new itemModel();
        }
        onRecivedModels(models);
    }

    public void onRecivedModels(itemModel[] models){
        for(int i = curImage; i<countImages; i++){
            GameObject instance = Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);

            StartCoroutine(InitializeItemView(instance, models[i]));
        }
    }
    private IEnumerator InitializeItemView(GameObject viewGameObject, itemModel model){
        TestItemView view = new TestItemView(viewGameObject.transform);

        curImage++;

        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url+(curImage).ToString()+".jpg");

        yield return webRequest.SendWebRequest();

        if(webRequest.isDone == false){
            Debug.Log(webRequest.error);
        }
        else{
            Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            view.image.sprite = Sprite.Create((Texture2D)texture, new Rect(0f,0f,texture.width,texture.height), Vector2.zero);
        }
    }
    public class TestItemView{
        public Image image;

        public TestItemView(Transform rootView){
            image = rootView.Find("image").GetComponent<Image>();
        }
    }

    public class itemModel{
        public Image image;
    }
}
