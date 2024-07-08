using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private float doorTimer;
    private bool doorOpen;

    void Start()
    {
        doorTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen == false && Time.time > doorTimer + 3f)
        {
            transform.DOMove(transform.position + Vector3.down, 1f).SetEase(Ease.Linear);
            doorOpen = true;
        }
    }
}
