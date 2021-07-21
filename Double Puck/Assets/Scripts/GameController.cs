using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject BlueWasher;
    public GameObject RedWasher;
    public Transform PlayersTransform;
    public Transform[] StartPositions;
    public Transform[] TargetPositions;
    /* public GameObject BlueHockeyPlayer;
    public GameObject RedHockeyPlayer;*/
    [HideInInspector]
    public GameObject washer;
    private Transform washer_transform;
    public Transform PlayPanel;
    private const float vertical_speed = 220;
    private const float horizontal_speed = 89;
    public TextMeshProUGUI Score;
    public GameObject Circle;
    [HideInInspector]
    public static int Washer_pos;
    [HideInInspector]
    public void WasherAppearing()
    {
        int WasherColorRandomizer = Random.Range(0, 2);
        if (WasherColorRandomizer == 0)
        {
            washer = Instantiate(BlueWasher, PlayPanel);
        }
        else
        {
            washer = Instantiate(RedWasher, PlayPanel);
        }
        washer.transform.SetSiblingIndex(2);
        washer_transform = washer.transform;
        switch (Washer_pos)
        {

            case 0:
                {
                    washer_transform.position = StartPositions[0].position;
                   // washer_transform.localPosition = new Vector2(188, /*240*/0);
                    break;
                }
            case 1:
                {
                    washer_transform.position = StartPositions[1].position;
                    // washer_transform.localPosition = new Vector2(/*239*/-8.2f, -307.8f);
                    break;
                }
            case 2:
                {
                    washer_transform.position = StartPositions[2].position;
                    // washer_transform.localPosition = new Vector2(-188, 7.7f);
                    break;
                }
            case 3:
                {
                    washer_transform.position = StartPositions[3].position;
                    //washer_transform.localPosition = new Vector2(0, 307.8f);
                    break;
                }
        }
        StartCoroutine(WasherMoving());
    }   
    private void Checkthehit(Vector3 RightVector, Vector3 WrongVector)
    {
        if (washer.tag == "BlueWasher")
        {
            if (PlayersTransform.eulerAngles == RightVector)
            {
                int score = System.Convert.ToInt32(Score.text);
                ++score;
                Score.text = score.ToString();
                FindObjectOfType<AudioManager>().Play("hit the puck");
                GetComponent<ArrowController>().ArrowAppearing();
                Destroy(washer);
            }
            else if (PlayersTransform.eulerAngles == WrongVector)
            {
                FindObjectOfType<AudioManager>().Play("player caught another color");
                GetComponent<LifeController>().LifeDecreasing(2);
                Destroy(washer);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("puck hit the side of the hockey players");
                StartCoroutine(WasherRebound());
            }
        }
        else
        {
            if (PlayersTransform.eulerAngles == WrongVector)
            {
                int score = System.Convert.ToInt32(Score.text);
                ++score;
                Score.text = score.ToString();
                FindObjectOfType<AudioManager>().Play("hit the puck");
                GetComponent<ArrowController>().ArrowAppearing();
                Destroy(washer);
            }
            else if (PlayersTransform.eulerAngles == RightVector)
            {
                FindObjectOfType<AudioManager>().Play("player caught another color");
                Destroy(washer);
                GetComponent<LifeController>().LifeDecreasing(2);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("puck hit the side of the hockey players");
                StartCoroutine(WasherRebound());
            }
        }
    }
    private IEnumerator WasherMoving()
    {        
        while(washer.transform.localPosition != TargetPositions[Washer_pos].localPosition)
        {
            while (Time.timeScale == 0)
            {
                yield return 0;
            }
            if (Washer_pos == 0 || Washer_pos == 2)
            {
                washer.transform.localPosition = Vector2.MoveTowards(washer.transform.localPosition, TargetPositions[Washer_pos].localPosition,horizontal_speed * Time.deltaTime);
            }
            else if (Washer_pos == 1 || Washer_pos == 3)
            {
                washer.transform.localPosition = Vector2.MoveTowards(washer.transform.localPosition, TargetPositions[Washer_pos].localPosition, vertical_speed * Time.deltaTime);
            }
            yield return 0;
        }
        Circle.SetActive(true);
        Circle.GetComponent<Animation>().Play("CircleAnim");
        PlayersTransform.gameObject.GetComponent<Animation>().Play("PlayerAnim");
        switch (Washer_pos)
        {
            case 0:
                {
                    Checkthehit(new Vector3(0, 0, 270), new Vector3(0, 0, 90));
                    break;
                }
            case 1:
                {
                    Checkthehit(new Vector3(0, 0, 180), new Vector3(0, 0, 0));
                    break;
                }
            case 2:
                {
                    Checkthehit(new Vector3(0, 0, 90), new Vector3(0, 0, 270));
                    break;
                }
            case 3:
                {
                    Checkthehit(new Vector3(0, 0, 0), new Vector3(0, 0, 180));
                    break;
                }
        }

    }
    private IEnumerator WasherRebound()
    {
        while (washer.transform.localPosition != StartPositions[Washer_pos].localPosition)
        {
            while (Time.timeScale == 0)
            {
                yield return 0;
            }
            if (Washer_pos == 0 || Washer_pos == 2)
            {
                washer.transform.localPosition = Vector2.MoveTowards(washer.transform.localPosition, StartPositions[Washer_pos].localPosition, horizontal_speed * 3 * Time.deltaTime);
            }
            else if(Washer_pos == 1 || Washer_pos == 3)
            {
                washer.transform.localPosition = Vector2.MoveTowards(washer.transform.localPosition, StartPositions[Washer_pos].localPosition, vertical_speed * 3 * Time.deltaTime);
            }       
            yield return 0;
        }
        Destroy(washer);
        GetComponent<LifeController>().LifeDecreasing(1);
    }    
}
