using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicPacManMovement : MonoBehaviour
{

    // apply to empty game object parent of pacman

    private float reloadTime = 0.25f;
    private float lastMoveTime = -0.25f;
    public Vector3 movementStore;
    public Eating eatingScript;

    Dictionary<string, Vector3> movementStateDict = new Dictionary<string, Vector3>();

    void Start()
    {
        movementStateDict.Add("forward", Vector3.forward);
        movementStateDict.Add("back", Vector3.back);
        movementStateDict.Add("left", Vector3.left);
        movementStateDict.Add("right", Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastMoveTime + reloadTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.DOMove(transform.position + Vector3.forward, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
                movementStore = movementStateDict["forward"];
                eatingScript.PlayAnimation(true);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DOMove(transform.position + Vector3.left, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
                movementStore = movementStateDict["left"];
                eatingScript.PlayAnimation(true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DOMove(transform.position + Vector3.back, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
                movementStore = movementStateDict["back"];
                eatingScript.PlayAnimation(true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DOMove(transform.position + Vector3.right, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
                movementStore = movementStateDict["right"];
                eatingScript.PlayAnimation(true);
            }
        }
    }
}
