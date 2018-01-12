using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpBtn : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

    public void OnPointerDown(PointerEventData data) {
        
        if (PlayerJump.instance)
        {
            PlayerJump.instance.SetPower(true);
            Debug.Log("Press down");
        }
    }


    public void OnPointerUp(PointerEventData data)
    {
        
        if (PlayerJump.instance)
        {
            Debug.Log("Press Up");
            PlayerJump.instance.SetPower(false);
        }
    }
}
