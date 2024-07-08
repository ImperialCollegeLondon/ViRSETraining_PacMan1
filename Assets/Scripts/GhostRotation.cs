using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRotation : MonoBehaviour
{
    public GhostMovement movementScript;
    void Start()
    {
        
    }


    void Update()
    {
        if (movementScript.lastMovement == Vector3.forward)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        if (movementScript.lastMovement == Vector3.left)
        {
            transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (movementScript.lastMovement == Vector3.back)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movementScript.lastMovement == Vector3.right)
        {
            transform.localEulerAngles = new Vector3(0f, 270f, 0f);
        }
    }
}
