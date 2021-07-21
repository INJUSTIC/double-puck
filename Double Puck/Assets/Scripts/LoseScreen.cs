using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI BestScore;
    public GameObject PlayScreen;
    public GameObject MenuPanel;
    private void OnEnable()
    {
        Score.text = PlayScreen.GetComponent<GameController>().Score.text;
        int score = System.Convert.ToInt32(Score.text);
        int bestscore = System.Convert.ToInt32(SaveSystem.LoadBestScore());
        BestScore.text = bestscore.ToString();
        if (score > bestscore)
        {
            BestScore.text = Score.text;
            SaveSystem.SaveBestScore(BestScore.text);
        }
    }
    public void OnRestartClicked()
    {
        PlayScreen.GetComponent<ArrowController>().StartPlay();
        gameObject.SetActive(false);
    }
    public void OnMenuClicked()
    {
        FindObjectOfType<AudioManager>().Stop("lose screen");
        gameObject.SetActive(false);
        PlayScreen.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
