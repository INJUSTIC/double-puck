using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Leaders : MonoBehaviour
{
    public string[] Names;
    public TextMeshProUGUI[] NamesUI = new TextMeshProUGUI[10];
    public TextMeshProUGUI[] ScoresUI = new TextMeshProUGUI[10];
    private string[] names = new string[9];
    private string[] scores = new string[9];
    public GameObject MainMenuPanel;
    public Transform[] LeadersPositions = new Transform[10];
   /* public TextMeshProUGUI MyScore;
    public TextMeshProUGUI MyName;*/
    public float[] leadersYPositions = new float[10];
    // public Transform[] leaders = new Transform[10];
    private void Awake()
    {
        if (PlayerPrefs.GetInt("names") == 1)
        {
            DateTime dateTime = SaveSystem.LoadTime();
            if (DateTime.UtcNow.Subtract(dateTime).TotalDays >= 7)
            {
                SaveSystem.SaveTime(DateTime.UtcNow);
                string[] namess = SaveSystem.LoadNames();
                string[] scoress = SaveSystem.LoadScores();
                for (int i = 0; i < names.Length;)
                {
                    bool IsDublicated = false;
                    int name_number = UnityEngine.Random.Range(0, Names.Length);
                    names[i] = Names[name_number];
                    for (int j = 0; j < i; ++j)
                    {
                        if (names[i] == names[j])
                        {
                            IsDublicated = true;
                            break;
                        }
                    }
                    if(!IsDublicated)
                    {
                        for (int k = 0; k < names.Length; ++k)
                        {
                            if (names[i] == namess[k])
                            {
                                IsDublicated = true;
                                break;
                            }
                        }
                    }                
                    if (!IsDublicated)
                    {
                        ++i;                          
                    }
                }
                SaveSystem.SaveNames(names);
                for (int i = 0; i < scores.Length; ++i)
                {
                    int score = UnityEngine.Random.Range(1, 11) + Convert.ToInt32(scoress[i]);
                    scores[i] = score.ToString();
                }
                SaveSystem.SaveScores(scores);
            }
        }
    }
    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("names") != 1)
        {
            SaveSystem.SaveTime(DateTime.UtcNow);
            for (int i = 0; i < names.Length;)
            {
                bool IsDublicated = false;
                int name_number = UnityEngine.Random.Range(0, Names.Length);
                names[i] = Names[name_number];
                for (int j = 0; j < i; ++j)
                {
                    if (names[i] == names[j])
                    {
                        IsDublicated = true;
                        break;
                    }
                }
                if (!IsDublicated)
                {
                    NamesUI[i].text = names[i];
                    ++i;
                }
            }
            SaveSystem.SaveNames(names);
            for (int i = 0; i < scores.Length; ++i)
            {
                int score = UnityEngine.Random.Range(1, 35);
                scores[i] = score.ToString();
                ScoresUI[i].text = scores[i];
            }
            SaveSystem.SaveScores(scores);
            PlayerPrefs.SetInt("names", 1);
        }
        else
        {
            //PlayerPrefs.DeleteAll();
            for (int i = 0; i < NamesUI.Length - 1; ++i)
            {
                NamesUI[i].text = SaveSystem.LoadNames()[i];
                ScoresUI[i].text = SaveSystem.LoadScores()[i];
            }
        }
        SortLeadersTable();
    }
    private void SortLeadersTable()
    {
        ScoresUI[ScoresUI.Length - 1].text = SaveSystem.LoadBestScore();
        Array.Sort(LeadersPositions,(x, y) => Convert.ToInt32(y.GetChild(0).GetComponent<TextMeshProUGUI>().text).CompareTo(Convert.ToInt32(x.GetChild(0).GetComponent<TextMeshProUGUI>().text)));
        for (int i = 0; i < ScoresUI.Length; ++i)
        {
            LeadersPositions[i].localPosition = new Vector2(7.19f, leadersYPositions[i]);
        }       
    }

    public void OnBackLeadersClicked()
    {
        MainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
