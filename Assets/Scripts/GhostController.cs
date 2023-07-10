using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using DG.Tweening;
using Unity.VisualScripting;
using System.Linq;

public class GhostController : MonoBehaviour
{
    public GameObject ghost;
    public float Ghostspeed = 1;
    private List<Vector3> PossibleDirections = new List<Vector3>();
    private List<Vector3> futureDir = new List<Vector3>();

    private int direction;
    public Vector3 currentDirection = Vector3.zero;
    private int wall;
    private Vector3 rightdir;
    private Vector3 leftdir;
    private Vector3 updir;
    private Vector3 downdir;
    private Vector3 olddir;
    private int newdir;


    // Start is called before the first frame update
    void Start()
    {
         newdir = 0;
        PossibleDirections.Add(Vector3.forward);//0
        PossibleDirections.Add(Vector3.right);//1
        PossibleDirections.Add(Vector3.left);//2
        PossibleDirections.Add(Vector3.back);//3
        
        wall = LayerMask.GetMask("Wall");
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void Move()
    {

        
        futureDir.Clear();
        Ray forwardRay = new Ray(transform.position, PossibleDirections[0]);
        Ray rightRay = new Ray(transform.position, PossibleDirections[1]);
        Ray backRay = new Ray(transform.position, PossibleDirections[3]);
        Ray leftRay = new Ray(transform.position, PossibleDirections[2]);


        //Debug.Log(direction);
        if (!Physics.Raycast(forwardRay, 1f, wall)) // move up
        {
            futureDir.Add(PossibleDirections[0]);
            //gameObject.transform.DOMove(transform.position + Vector3.forward * Ghostspeed, 0.5f);
        }
        if (!Physics.Raycast(rightRay, 1f, wall)) // move right
        {
            futureDir.Add(PossibleDirections[1]);
            //gameObject.transform.DOMove(transform.position + Vector3.right * Ghostspeed, 0.5f);
        }
        if (!Physics.Raycast(leftRay, 1f, wall)) // move left 
        {
            futureDir.Add(PossibleDirections[2]);
            //gameObject.transform.DOMove(transform.position + Vector3.left * Ghostspeed, 0.5f);
        }
        if (!Physics.Raycast(backRay, 1f, wall)) //move down 
        {
            futureDir.Add(PossibleDirections[3]);
            //gameObject.transform.DOMove(transform.position + Vector3.back * Ghostspeed, 0.5f);
        }
        Debug.Log(olddir);
        futureDir.Remove(-olddir);
        newdir = Random.Range(0, futureDir.Count());

        olddir = futureDir[newdir]; 

        gameObject.transform.DOMove(transform.position + futureDir[newdir], 0.5f).SetEase(Ease.Linear).OnComplete(() => Move());

        /*if (currentDirection != Vector3.zero)
        {
            transform.LookAt(moveTo);
        }
        transform.DOMove(moveTo, 1 / Ghostspeed).SetEase(Ease.Linear).OnComplete(() => Move());*/
    }

}
