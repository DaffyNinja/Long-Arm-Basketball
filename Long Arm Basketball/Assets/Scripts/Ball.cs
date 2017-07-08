using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool isTouchingHand;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Hand")
        {
            isTouchingHand = true;
        }

    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Hand")
        {
            isTouchingHand = false;
        }

    }


}
