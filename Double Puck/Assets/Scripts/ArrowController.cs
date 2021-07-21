using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{  
    public GameObject ArrowTwice;
    private GameObject arrow_twice;
    public Transform[] ArrowParents;
    [HideInInspector]
    public bool IsFirst;
    public Transform PlayPanel;
    public GameObject Players;

    Stopwatch sw;
    [HideInInspector]
    public void StartPlay()
    {
        if(arrow_twice != null)
        {
            Destroy(arrow_twice);
        }
        if (GetComponent<GameController>().washer != null)
        {
            Destroy(GetComponent<GameController>().washer);
        }
        //arrow_twice = null;
        LifeController.LifeAmount = 2;
        IsFirst = true;
        PlayerRotation.touchamount = 0;
        FindObjectOfType<PlayerRotation>().transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<GameController>().Score.text = "0";
        sw = new Stopwatch();
        sw.Start();
    }
    private void Update()
    {
        if(IsFirst && sw.ElapsedMilliseconds >= 1200)
        {
            ArrowAppearing();
            sw.Stop();
            IsFirst = false;
        }
    }
    [HideInInspector]
    public void ArrowAppearing()
    {
        int arrow_pos = Random.Range(0, 4);
        arrow_twice = Instantiate(ArrowTwice, ArrowParents[arrow_pos]);
        GameController.Washer_pos = arrow_pos;
        arrow_twice.transform.position = ArrowParents[arrow_pos].position;       
        StartCoroutine(ArrowAnim());
    }
    private IEnumerator ArrowAnim()
    {
        yield return new WaitForSeconds(0.3f);
        Image image = arrow_twice.GetComponent<Image>();
        for(int i = 0; i < 2; ++i)
        {
            while (image.color.a < 1)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.2f);
                yield return new WaitForSeconds(0.02f);
            }
            while (image.color.a > 0)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.2f);
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(0.1f);
        }       
        arrow_twice.SetActive(false);
        Destroy(arrow_twice);
        FindObjectOfType<GameController>().WasherAppearing();
    }
}
