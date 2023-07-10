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
        Ray ray = new Ray(transform.position, currentDirection);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 1))
        {
            Debug.Log(hitinfo.collider.gameObject.name);
            currentDirection = Vector3.zero;
        }

        Debug.Log(currentDirection);
        if (currentDirection != Vector3.zero)
        {
            transform.LookAt(currentDirection + transform.position);
        }
        transform.DOMove(transform.position + currentDirection, 1).SetEase(Ease.Linear).OnComplete( () => Move() );
    }
}
