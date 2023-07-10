using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    private Vector3 currentDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentDirection = Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentDirection = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDirection = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentDirection = Vector3.right;
        }
    }

    void Move()
    {
        if (Physics.Raycast(transform.position, transform.position + currentDirection, 1))
        {
            currentDirection = Vector3.zero;
        }
        transform.DOMove(transform.position + currentDirection, 1).OnComplete( () => Move() );
    }
}
