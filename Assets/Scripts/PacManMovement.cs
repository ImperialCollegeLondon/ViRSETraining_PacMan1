using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.ReorderableList;

public class PacManMovement : MonoBehaviour
{
    private float reloadTime = 0.25f;
    private float lastMoveTime = 0f;
    private Vector3 movementStore;
    private float xMod;
    private float zMod;
    public float distanceToWall;
    private bool moving = false;
    private float velocity = 4f;

    Dictionary<string, Vector3> movementStateDict = new Dictionary<string, Vector3>();

    void Start()
    {
        movementStateDict.Add("forward", Vector3.forward);
        movementStateDict.Add("back", Vector3.back);
        movementStateDict.Add("left", Vector3.left);
        movementStateDict.Add("right", Vector3.right);
    }


    void FixedUpdate()
    {
        xMod = transform.position.x % 1;
        zMod = transform.position.x % 1;

        if (moving)
        {
            if (zMod != 0 || xMod != 0) // packman can only move opposite/same as current direction
            {
                // don't do move, just record for next movement

                if (Input.GetKeyDown(KeyCode.W))
                {
                    movementStore = movementStateDict["forward"];
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    movementStore = movementStateDict["back"];
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    movementStore = movementStateDict["left"];
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movementStore = movementStateDict["right"];
                }
            }

            else if (zMod == 0 && xMod == 0)          // waits til integer z and then moves again
            {
                //transform.DOMove(transform.position + movementStore * distanceToWall, reloadTime).SetEase(Ease.Linear);
                transform.position += movementStore * velocity * Time.deltaTime;
                moving = true;
            }
        }


       





            if (Input.GetKeyDown(KeyCode.W))
            {
            //                transform.DOMove(transform.position + Vector3.forward * distanceToWall, reloadTime).SetEase(Ease.Linear);
            transform.position += Vector3.forward * velocity * Time.deltaTime;
            movementStore = movementStateDict["forward"];
            moving = true;
            }



            if (Input.GetKeyDown(KeyCode.A))
            {
            //                transform.DOMove(transform.position + Vector3.left * distanceToWall, reloadTime).SetEase(Ease.Linear);
            transform.position += Vector3.left * velocity * Time.deltaTime;
            movementStore = movementStateDict["left"];
            moving = true;
        }


            if (Input.GetKeyDown(KeyCode.S))
            {
            //transform.DOMove(transform.position + Vector3.back * distanceToWall, reloadTime).SetEase(Ease.Linear);
            transform.position += Vector3.back * velocity * Time.deltaTime;
            movementStore = movementStateDict["back"];
            moving = true;
        }


            if (Input.GetKeyDown(KeyCode.D))
            {
            //  transform.DOMove(transform.position + Vector3.right * distanceToWall, reloadTime).SetEase(Ease.Linear);
            transform.position += Vector3.right * velocity * Time.deltaTime;
            movementStore = movementStateDict["right"];
            moving = true;
        }  
    }
}
