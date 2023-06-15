using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class loadingScript : MonoBehaviour
{
    private float progressLoading = 0;

    public TMP_Text loadingPercentage;
    public Image loadingProgressBar;
    
    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void loadScene(int idScene)
    {
        dataHolder.instance.componentAnimator.SetTrigger("sceneClosing");

        dataHolder.instance.loadingSceneOperation = SceneManager.LoadSceneAsync(idScene);
        
        dataHolder.instance.loadingSceneOperation.allowSceneActivation = false;
    
        dataHolder.instance.loadingProgressBar.fillAmount = 0;
    }
    
    private void Start()
    {
        dataHolder.instance = this;

        componentAnimator = GetComponent<Animator>();
        
        if (dataHolder.shouldPlayOpeningAnimation) 
        {
            componentAnimator.SetTrigger("sceneOpening");

            dataHolder.instance.loadingProgressBar.fillAmount = 1;
            
            dataHolder.shouldPlayOpeningAnimation = false; 
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            progressLoading = Mathf.Lerp(progressLoading, loadingSceneOperation.progress*100f, Time.deltaTime*5f);
            loadingPercentage.text = Mathf.RoundToInt(progressLoading) + "%";
            loadingProgressBar.fillAmount = Mathf.Lerp(loadingProgressBar.fillAmount, loadingSceneOperation.progress, Time.deltaTime * 5f);
        }
    }

    public void OnAnimationOver()
    {
        dataHolder.shouldPlayOpeningAnimation = true;
        
        loadingSceneOperation.allowSceneActivation = true;
    }
}