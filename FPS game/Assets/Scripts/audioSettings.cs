using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    [SerializeField] private AudioSource confirmSound;
    [SerializeField] private AudioSource cancelSound;

    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject previousScreen;

    private float masterVolume;
    private float musicVolume;
    private float effectsVolume;
    private bool masterOn;
    private bool musicOn;
    private bool effectsOn;

    [SerializeField] private Toggle masterToggle;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle effectsToggle;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    private void Start() {
        masterToggle.isOn = PlayerPrefs.GetInt("masterToggle", 1) == 1;
        musicToggle.isOn = PlayerPrefs.GetInt("musicToggle", 1) == 1;
        effectsToggle.isOn = PlayerPrefs.GetInt("effectsToggle", 1) == 1;
        masterSlider.value = PlayerPrefs.GetFloat("masterSlider", 0f);
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider", 0f);
        effectsSlider.value = PlayerPrefs.GetFloat("effectsSlider", 0f);
    }

    public void offMaster(){
        masterOn = masterToggle.isOn;

        if(masterOn){
            mixer.audioMixer.SetFloat("masterVolume", masterVolume);
        }
        else{
            mixer.audioMixer.SetFloat("masterVolume", -80f);
        }

        confirmSound.Play();
    }
    public void offMusic(){
        musicOn = musicToggle.isOn;

        if(musicOn){
            mixer.audioMixer.SetFloat("musicVolume", musicVolume);
        }
        else{
            mixer.audioMixer.SetFloat("musicVolume", -80f);
        }

        confirmSound.Play();
    }
    public void offEffects(){
        effectsOn = effectsToggle.isOn;

        if(effectsOn){
            mixer.audioMixer.SetFloat("effectsVolume", effectsVolume);
        }
        else{
            mixer.audioMixer.SetFloat("effectsVolume", -80f);
        }

        confirmSound.Play();
    }

    public void changeMasterVolume(){
        masterVolume = masterSlider.value;

        mixer.audioMixer.SetFloat("masterVolume", masterVolume);
    }
    public void changeMusicVolume(){
        musicVolume = musicSlider.value;

        mixer.audioMixer.SetFloat("musicVolume", musicVolume);
    }
    public void changeEffectsVolume(){
        effectsVolume = effectsSlider.value;

        mixer.audioMixer.SetFloat("effectsVolume", effectsVolume);
    }

    public void applySettings(){
        PlayerPrefs.SetInt("masterToggle", masterOn ? 1 : 0);
        PlayerPrefs.SetInt("musicToggle", musicOn ? 1 : 0);
        PlayerPrefs.SetInt("effectsToggle", effectsOn ? 1 : 0);
        PlayerPrefs.SetFloat("masterSlider", masterVolume);
        PlayerPrefs.SetFloat("musicSlider", musicVolume);
        PlayerPrefs.SetFloat("effectsSlider", effectsVolume);

        confirmSound.Play();
    }

    public void settingsOpen(){
        confirmSound.Play();

        settingsScreen.SetActive(true);
        previousScreen.SetActive(false);
    }

    public void settingsClose(){
        cancelSound.Play();

        settingsScreen.SetActive(false);
        previousScreen.SetActive(true);
    }
}
