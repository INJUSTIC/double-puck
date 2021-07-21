using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject LanguagePanel;
    public GameObject SettingsPanel;
    public GameObject MainMenuPanel;
    public Image SoundImage;
    public Sprite EnabledSound;
    public Sprite DisabledSound;
   // public Vector3 HugeLanguageButtonSize;
    private void Start()
    {
        if(AudioManager.SoundIsEnabled)
        {
            SoundImage.sprite = EnabledSound;
        }
        else
        {
            SoundImage.sprite = DisabledSound;
        }
         
    }
    public void OnBackSettingsClicked()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void OnLanguageClicked()
    {
        LanguagePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void OnLanguageBackClicked()
    {
        SettingsPanel.SetActive(true);
        LanguagePanel.SetActive(false);
    }  
    public void OnSoundButtonClicked()
    {
        if (AudioManager.SoundIsEnabled)
        {
            SoundImage.sprite = DisabledSound;
        }
        else
        {
            SoundImage.sprite = EnabledSound;
        }
        AudioManager.SoundIsEnabled = !AudioManager.SoundIsEnabled;
        SaveSystem.SaveSoundIsEnabled(AudioManager.SoundIsEnabled);
    }
    public void OnRemoveProgressClicked()
    {
        SaveSystem.SaveBestScore("0");
    }
}
