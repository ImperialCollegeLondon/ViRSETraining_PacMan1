using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using DG.Tweening;

public class Controller : MonoBehaviour
{
    private float speed = 0.2f;    // the bigger, the smaller the speed
    public static Controller instance;
    public Vector3 currentDirection = Vector3.zero;
    private Vector3 nextDirection = Vector3.zero;

    private int wall;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Move();
        wall = LayerMask.GetMask("Wall");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            nextDirection = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            nextDirection = Vector3.back;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            nextDirection = Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            nextDirection = Vector3.right;
    }

    void Move()
    {
        currentDirection = nextDirection;

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


        // Teleport
        if (gameObject.transform.position.x < -14.5f)
        {
            //speed = 0.01f;
            moveTo = new Vector3(14, 1, 3);
            gameObject.transform.position = new Vector3(15, 1, 3);
            gameObject.GetComponent<Rigidbody>().position = new Vector3(15, 1, 3);
        }

        if (gameObject.transform.position.x > 15.5f)
        {
            //speed = 0.01f;
            moveTo = new Vector3(-13, 1, -7);
            gameObject.transform.position = new Vector3(-14, 1, -7);
            gameObject.GetComponent<Rigidbody>().position = new Vector3(-14, 1, -7);
        }
        transform.DOMove(moveTo, speed).SetEase(Ease.Linear).OnComplete( () => Move() );
    }
}
