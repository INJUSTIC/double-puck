using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    private Vector3 start_scale;
    private void Start()
    {
        start_scale = transform.localScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (tag != "Pause")
        {
            transform.localScale = new Vector3(start_scale.x*1.05f, start_scale.y*1.05f, start_scale.z*1.05f);
        }
        else
        {
            Pause.OnPauseDown = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tag != "Pause")
        {
            transform.localScale = new Vector3(start_scale.x, start_scale.y, start_scale.z);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (tag != "Pause")
        {
            transform.localScale = new Vector3(start_scale.x, start_scale.y, start_scale.z);
        }
        else
        {
            Pause.OnPauseDown = false;
        }
    }
}
