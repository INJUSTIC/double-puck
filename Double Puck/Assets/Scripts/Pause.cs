using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public static bool OnPauseDown = false;
    public TextMeshProUGUI CurrentScoreUI;
    public TextMeshProUGUI CurrentScore;
    public GameObject PlayScreen;
    public GameObject MenuPanel;
    public void OnPauseClicked()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        CurrentScoreUI.text = CurrentScore.text;
        OnPauseDown = false;
    }
    public void OnResumeClicked()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnMenuClicked()
    {
        gameObject.SetActive(false);
        MenuPanel.SetActive(true);
        GameObject washer = FindObjectOfType<GameController>().washer;
        PlayScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
