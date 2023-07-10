using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    public float speed = 1;
    public static Controller instance;

    public Vector3 currentDirection = Vector3.zero;
    private int wall;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Move();
        wall = LayerMask.GetMask("Wall");
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
        if (Physics.Raycast(ray, .6f, wall))
        {
            currentDirection = Vector3.zero;
        }
        Vector3 moveTo = transform.position + currentDirection;

        if (currentDirection != Vector3.zero)
        {
            transform.LookAt(moveTo);
        }
        transform.DOMove(moveTo, 1 / speed).SetEase(Ease.Linear).OnComplete( () => Move() );
    }
}
