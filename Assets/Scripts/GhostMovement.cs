using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private float reloadTime = 0.25f;
    private float lastMoveTime = -0.25f;
    public Vector3 lastMovement;
    public int mode;
    public float rayHeight;

    private bool doorOpen;
    private float doorTimer;


    List<Vector3> possibleMovements = new List<Vector3>();

    Dictionary<string, Vector3> movementStateDict = new Dictionary<string, Vector3>();

    private Vector3 ReverseMoveFinder()
    {
        Vector3 reverseMove = lastMovement * -1f;
        return reverseMove;
    }


    void Start()
    {
        doorTimer = Time.time;
        movementStateDict.Add("forward", Vector3.forward);
        movementStateDict.Add("back", Vector3.back);
        movementStateDict.Add("left", Vector3.left);
        movementStateDict.Add("right", Vector3.right);
    }

   
    void FixedUpdate()
    {
        LayerMask wallsOnly = LayerMask.GetMask("Wall");

        if (Time.time >= lastMoveTime + reloadTime)
        {
            Ray forwardRay = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), movementStateDict["forward"]);
            Ray backRay = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), movementStateDict["back"]);
            Ray leftRay = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), movementStateDict["left"]);
            Ray rightRay = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), movementStateDict["right"]);

            if (!Physics.Raycast(forwardRay, out RaycastHit forwardHitInfo, 1, wallsOnly))
            {
                possibleMovements.Add(movementStateDict["forward"]);
            }
            if (!Physics.Raycast(backRay, out RaycastHit backHitInfo, 1, wallsOnly))
            {
                possibleMovements.Add(movementStateDict["back"]);
            }
            if (!Physics.Raycast(leftRay, out RaycastHit leftHitInfo, 1, wallsOnly))
            {
                possibleMovements.Add(movementStateDict["left"]);
            }
            if (!Physics.Raycast(rightRay, out RaycastHit rightHitInfo, 1, wallsOnly))
            {
                possibleMovements.Add(movementStateDict["right"]);
            }
            
            if (possibleMovements.Count == 1)
            {
                transform.DOMove(transform.position + possibleMovements[0], reloadTime).SetEase(Ease.Linear);
                lastMovement = possibleMovements[0];
                lastMoveTime = Time.time;
            }

            

            else if (possibleMovements.Count > 1)
            {
                if (doorOpen == false && Time.time > doorTimer + 3f && possibleMovements.Contains(movementStateDict["forward"]))
                {
                    transform.DOMove(transform.position + movementStateDict["forward"], reloadTime).SetEase(Ease.Linear);
                    doorOpen = true;
                    lastMovement = movementStateDict["forward"];
                    lastMoveTime = Time.time;
                }
                else
                {
                    if (doorOpen && transform.position.z == 2)
                    {
                        if (transform.position.x <= -6 && transform.position.x >= -8)
                        {
                            possibleMovements.Remove(movementStateDict["back"]);
                        }
                    }

                    possibleMovements.Remove(ReverseMoveFinder());

                    int randomMovement = Random.Range(0, possibleMovements.Count);

                    transform.DOMove(transform.position + possibleMovements[randomMovement], reloadTime).SetEase(Ease.Linear);
                    lastMovement = possibleMovements[randomMovement];
                    lastMoveTime = Time.time;
                }
            }

            else
            {
                lastMoveTime = -0.25f;
            }

        }
        possibleMovements.Clear();
        
        if (transform.position.x > 14f)
        {
            transform.position = new Vector3(-14f, 0f, 0f);
        }

        if (transform.position.x < -14f)
        {
            transform.position = new Vector3(14f, 0f, 0f);
        }
    }
}