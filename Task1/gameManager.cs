using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private int curSceneIndex;
    private void Start() {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(curSceneIndex != 2){
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
        }
        else{
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
        }
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && curSceneIndex != 0){
            loadingScript.loadScene(curSceneIndex-1);
        }
    }
    public void loadMenuScene(){
        loadingScript.loadScene(0);
    }
    public void loadGalleryScene(){
        loadingScript.loadScene(1);
    }
    public void exit(){
        Application.Quit();
    }
}