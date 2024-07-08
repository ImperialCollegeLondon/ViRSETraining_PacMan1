using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManRotation : MonoBehaviour
{
    public BasicPacManMovement movementScript;

    // apply to pacman itself (child of empty game object parent)


    void Start()
    {
        
    }


    void Update()
    {
        if (movementScript.movementStore == Vector3.forward)
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if (movementScript.movementStore == Vector3.left)
        {
            transform.localEulerAngles = new Vector3(0f, 270f, 0f);
        }

        if (movementScript.movementStore == Vector3.back)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movementScript.movementStore == Vector3.right)
        {
            transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        }
    }
}
