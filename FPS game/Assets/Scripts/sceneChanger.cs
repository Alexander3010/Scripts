using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneChanger : MonoBehaviour
{
    [SerializeField] private Animator loadAnimator;
    [SerializeField] private Slider loadSlider;
    private float loadProgress;

    [SerializeField] private AudioSource confirmSound;
    [SerializeField] private AudioSource cancelSound;

    [SerializeField] private GameObject loadScreen;

    public void loadLevel1(){
        confirmSound.Play();
        StartCoroutine(sceneLoad("level1"));
    }
    public void loadLevelMenu(){
        cancelSound.Play();
        StartCoroutine(sceneLoad("mainMenuScene"));
    }
    public void exit(){
        Application.Quit();
    }
    private IEnumerator sceneLoad(string sceneName){
        SceneManager.LoadScene(sceneName);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        loadScreen.SetActive(true);
        loadAnimator.SetTrigger("loadTrigger");
        
        while(!loadOperation.isDone){
            loadProgress = Mathf.Clamp01(loadOperation.progress /0.9f);
            loadSlider.value = loadProgress;
            yield return null;
        }
    }
}
