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

    public int minX = -4;
    public int maxX = 4;
    public int minZ = -4;
    public int maxZ = 4;

    private float dx;
    private float dz;

    private void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Move();
        wall = LayerMask.GetMask("Wall");
        dx = maxX - minX;
        dz = maxZ - minZ;
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

        // Teleport
        if (moveTo.x < minX)
        {
            transform.position += new Vector3(dx, 0, 0);
            moveTo += new Vector3(dx, 0, 0);
        }
        if (moveTo.x > maxX)
        {
            transform.position -= new Vector3(dx, 0, 0);
            moveTo -= new Vector3(dx, 0, 0);
        }
        if (moveTo.z < minZ)
        {
            transform.position += new Vector3(0, 0, dz);
            moveTo += new Vector3(dz, 0, 0);
        }
        if (moveTo.z > maxZ)
        {
            transform.position -= new Vector3(0, 0, dz);
            moveTo -= new Vector3(dz, 0, 0);
        }

        transform.DOMove(moveTo, 1 / speed).SetEase(Ease.Linear).OnComplete( () => Move() );
    }
}
