using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MainMenuPanel;
    public GameObject LeadersScreen;
    public GameObject PlayScreen;
    public void OnPlayClicked()
    {
        MainMenuPanel.SetActive(false);
        PlayScreen.SetActive(true);
        PlayScreen.GetComponent<ArrowController>().StartPlay();
    }
    public void OnSettingsClicked()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void OnLeadersClicked()
    {
        MainMenuPanel.SetActive(false);
        LeadersScreen.SetActive(true);
    }
}
