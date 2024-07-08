using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private float reloadTime = 0.25f;
    private float lastMoveTime = -0.25f;
    private Vector3 lastMovement;
    public int mode;

    List<Vector3> possibleMovements = new List<Vector3>();

    Dictionary<string, Vector3> movementStateDict = new Dictionary<string, Vector3>();

    private Vector3 ReverseMoveFinder()
    {
        Vector3 reverseMove = lastMovement * -1f;
        return reverseMove;
    }


    void Start()
    {
        movementStateDict.Add("forward", Vector3.forward);
        movementStateDict.Add("back", Vector3.back);
        movementStateDict.Add("left", Vector3.left);
        movementStateDict.Add("right", Vector3.right);
    }

   
    void Update()
    {
        if (Time.time >= lastMoveTime + reloadTime)
        {
            Ray forwardRay = new Ray(new Vector3(transform.position.x, -0.499f, transform.position.z), movementStateDict["forward"]);
            Ray backRay = new Ray(new Vector3(transform.position.x, -0.499f, transform.position.z), movementStateDict["back"]);
            Ray leftRay = new Ray(new Vector3(transform.position.x, -0.499f, transform.position.z), movementStateDict["left"]);
            Ray rightRay = new Ray(new Vector3(transform.position.x, -0.499f, transform.position.z), movementStateDict["right"]);

            if (!Physics.Raycast(forwardRay, out RaycastHit forwardHitInfo, 1))
            {
                possibleMovements.Add(movementStateDict["forward"]);
            }
            if (!Physics.Raycast(backRay, out RaycastHit backHitInfo, 1))
            {
                possibleMovements.Add(movementStateDict["back"]);
            }
            if (!Physics.Raycast(leftRay, out RaycastHit leftHitInfo, 1))
            {
                possibleMovements.Add(movementStateDict["left"]);
            }
            if (!Physics.Raycast(rightRay, out RaycastHit rightHitInfo, 1))
            {
                possibleMovements.Add(movementStateDict["right"]);
            }
            
            if (possibleMovements.Count == 1)
            {
                transform.DOMove(transform.position + possibleMovements[0], reloadTime).SetEase(Ease.Linear);
            }

            

            else
            {
                possibleMovements.Remove(ReverseMoveFinder());
            }

        }
        possibleMovements.Clear();
    }
}
