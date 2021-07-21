using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static int LifeAmount = 2;
    public GameObject LoseScreen;
    public void LifeDecreasing(int amount)
    {
        LifeAmount-= amount;
        if (LifeAmount <= 0)
        {
            //PlayerDeath();
            StartCoroutine(DeathAnim());
        }
        else
        {
            GetComponent<ArrowController>().ArrowAppearing();          
        }
    }
    private IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(0.5f);
        LoseScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("lose screen");
    }
}
