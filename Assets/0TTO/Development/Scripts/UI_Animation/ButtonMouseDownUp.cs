using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseDownUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        transform.parent.GetComponent<StartScreenExit>().tapDown = true;
        this.enabled = false;
    }

    public void OnPointerUp(PointerEventData data)
    {

    }
}