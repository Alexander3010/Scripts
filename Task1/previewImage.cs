using UnityEngine;
using UnityEngine.UI;

public class previewImage : MonoBehaviour
{
    private RectTransform rectTransform;
    private Image image;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        
        image.sprite = dataHolder.previewSprite;
    }

    private void Update() {
        if(Screen.height > Screen.width){
            rectTransform.localScale = new Vector3(1f,1f,1f);
        }
        else{
            rectTransform.localScale = new Vector3(0.5f,0.5f,1f);
        }
    }
}
