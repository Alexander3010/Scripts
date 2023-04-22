using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject previousScreen;

    [SerializeField] private AudioSource confirmSound;
    [SerializeField] private AudioSource cancelSound;

    public void tutorialOpen(){
        confirmSound.Play();

        tutorialScreen.SetActive(true);
        previousScreen.SetActive(false);
    }
    public void tutorialClose(){
        cancelSound.Play();

        tutorialScreen.SetActive(false);
        previousScreen.SetActive(true);
    }
}
