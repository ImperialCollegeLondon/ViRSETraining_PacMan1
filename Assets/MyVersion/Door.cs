using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float delay = 3f;

    private void Start()
    {
        DOVirtual.DelayedCall(2f, () => HideDoor());
    }

    private void HideDoor()
    {
        transform.DOMove(transform.position + Vector3.down, 1f);
    }
}
