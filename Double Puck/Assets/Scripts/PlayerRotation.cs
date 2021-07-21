using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public static int touchamount = 0;
    public GameObject LoseScreen;
    public GameObject PauseScreen;
    private void Update()
    {
        if(Input.touchCount > 0 && !LoseScreen.activeSelf && !Pause.OnPauseDown && !PauseScreen.activeSelf)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                touchamount++;
                if (touchamount == 4)
                {
                    touchamount = 0;
                }
                transform.rotation = Quaternion.Euler(0,0,-90*touchamount);
                
            }
        }
    }
}
