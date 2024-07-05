using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicPacManMovement : MonoBehaviour
{
    private float reloadTime = 0.25f;
    private float lastMoveTime = -0.25f;
    
    void Start()
    {
        
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
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DOMove(transform.position + Vector3.left, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DOMove(transform.position + Vector3.back, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DOMove(transform.position + Vector3.right, reloadTime).SetEase(Ease.Linear);
                lastMoveTime = Time.time;
            }
        }
    }
}
