using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    [SerializeField] private Button watchAd;
    [SerializeField] private Button continueAfterAd;
    [SerializeField] private Button[] Sound;
    [SerializeField] private GameObject deathMenuUI; 
    [SerializeField] private GameObject Master;
    [SerializeField] private Score _score;

    public Sprite soundOn;
    public Sprite soundOff;

    private void Start()
    {
        int soundSettings = PlayerPrefs.GetInt("SoundSettings", 1);

        if (soundSettings == 0)
        {
            Sound[0].GetComponent<Image>().sprite = soundOff;
            Sound[1].GetComponent<Image>().sprite = soundOff;
            AudioListener.pause = false;
        }
        else
        {
            Sound[0].GetComponent<Image>().sprite = soundOn;
            Sound[1].GetComponent<Image>().sprite = soundOn;
            AudioListener.pause = true;
        }
        
        watchAd.gameObject.SetActive(true); // WATCH AD - ON
        continueAfterAd.gameObject.SetActive(false); // CONTINUE - OFF
    }

    public void WatchAdClicked() // WATCH AD (BUTTON)
    {
        watchAd.gameObject.SetActive(false); // BUTTON OFF (WATCH AD)
        continueAfterAd.gameObject.SetActive(true); // BUTTON ON (CONTINUE)
        Pause();
    }

    public void ContinueAfterAdClicked() // CONTINUE (BUTTON)
    {
        deathMenuUI.SetActive(false); // UI MENU OFF
        //watchAd.gameObject.SetActive(true); // BUTTON WATCH AD - ON
        continueAfterAd.gameObject.SetActive(false); // CONTINUE - OFF
        Play();

        //v.1
        //transform.position = new Vector3(-2.43f, -3.24f, 0);
        //Destroy(GameObject.FindWithTag("Clear"));

    }
    
    public void SoundOffOn()
    {
        
        if (AudioListener.pause == true)
        {
            Sound[0].GetComponent<Image>().sprite = soundOff;
            Sound[1].GetComponent<Image>().sprite = soundOff;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("SoundSettings", 0);
        }
        else
        {
            Sound[0].GetComponent<Image>().sprite = soundOn;
            Sound[1].GetComponent<Image>().sprite = soundOn;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("SoundSettings", 1);
        }
    }

    private void Play()
    {
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
}
