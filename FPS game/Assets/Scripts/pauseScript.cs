using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    [SerializeField] private AudioSource pauseOnSound;
    [SerializeField] private AudioSource pauseOffSound;
    [SerializeField] private AudioSource inGameMusic;

    private bool isPaused = false;

    // values to lock control of player
    [SerializeField] private GameObject playerObject;
    private playerCamera cameraScript;
    private playerAttack attackScript;

    private void Start() {
        cameraScript = playerObject.GetComponent<playerCamera>();
        attackScript = playerObject.GetComponent<playerAttack>();

        pauseOff();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused){
            pauseOn();
        }
        else if(Input.GetKeyDown(KeyCode.Escape)&& isPaused){
            pauseOff();
        }
    }

    public void pauseOn(){
        isPaused = true;
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraScript.rotationCameraACtive = false;
        attackScript.ReloadShooting = true;

        pauseOnSound.Play();
        inGameMusic.Pause();
        pauseScreen.SetActive(true);
    }

    public void pauseOff(){
        isPaused = false;
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraScript.rotationCameraACtive = true;
        attackScript.ReloadShooting = false;
        
        pauseOffSound.Play();
        inGameMusic.Play();
        pauseScreen.SetActive(false);
    }
}
