using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class imageSaver : MonoBehaviour
{
    public void imageClick(){
        dataHolder.previewSprite = GetComponent<Image>().sprite;
        loadingScript.loadScene(2);
    }
}
