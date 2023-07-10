using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float time = Time.time;
        Vector3 i_position = gameObject.transform.position;

        if (time > 2f && time < 2.1f)
        {
            transform.DOMove(i_position + new Vector3(1, 0, 0), 3f).SetEase(Ease.Linear);
        }
    }
}
