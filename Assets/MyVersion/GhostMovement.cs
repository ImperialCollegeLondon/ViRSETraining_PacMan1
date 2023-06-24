using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Vector3 position = Vector3.zero;

    public bool moving = false;
    public float speed = .55f;
    public float animSpeed = 6f;
    private int lastMoveIndex = -1;
    //public GameObject upperPart, lowerPart;

    private int mode = 0;  //0=normal, 1=PP, 2=dead
    Color originalColor;
    private void Start()
    {
        position = transform.position;
        originalColor = hideablePartsWhenEaten[0].GetComponent<Renderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {
        if (!moving && mode!=2)
        {
            List<int> allowedMoves = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (CheckMove(GetMoveDirectionFromIndex(i)))
                    allowedMoves.Add(i);
            }

            if (allowedMoves.Count > 1 && lastMoveIndex >= 0)
                allowedMoves.Remove(OppositeTo(lastMoveIndex));

            int move = allowedMoves[Random.Range(0, allowedMoves.Count)];


            DoMove(GetMoveAngleFromIndex(move), GetMoveDirectionFromIndex(move));
            lastMoveIndex = move;
        }

        float animPhase = Mathf.Sin((transform.position.x + transform.position.z) * animSpeed);
        Animate(animPhase);

        DoColour();

    }

    private void DoColour()
    {
        if (mode == 1)
        {
            float animPhase = Mathf.Sin((transform.position.x + transform.position.z) * 10);
            animPhase += 1f;
            animPhase /= 2f;
            foreach (GameObject g in hideablePartsWhenEaten)
            {
                g.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.cyan, animPhase); ;
            }
        }
            
    }

    public GameObject eye1, eye2;
    public GameObject skirt1, skirt2, skirt3, skirt4;

    private void Animate(float animPhase)
    {
        eye1.transform.localEulerAngles = new Vector3(0f, animPhase * 30f +15f, 0f); 
        eye2.transform.localEulerAngles = new Vector3(0f, animPhase * 30f + 15f, 0f);
        skirt1.transform.localScale = new Vector3(0.4f, 0.4f, animPhase * .2f + .6f);
        skirt3.transform.localScale = new Vector3(0.4f, 0.4f, animPhase * .2f + .6f);
        skirt2.transform.localScale = new Vector3(0.4f, 0.4f, -animPhase * .2f + .6f);
        skirt4.transform.localScale = new Vector3(0.4f, 0.4f, -animPhase * .2f + .6f);
    }

    private int OppositeTo(int i)
    {
        switch (i)
        {
            case 0: return 1;
            case 1: return 0;
            case 2: return 3;
            case 3: return 2;
            default: return 0; //impossible, but C# insists
        }
    }

    private float GetMoveAngleFromIndex(int i)
    {
        switch (i)
        {
            case 0: return 0f;
            case 1: return 180f;
            case 2: return -90f;
            case 3: return 90f;
            default: return 0f; //impossible, but C# insists
        }
    }

    private Vector3 GetMoveDirectionFromIndex(int i)
    {
        switch (i)
        {
            case 0: return Vector3.forward;
            case 1: return Vector3.back;
            case 2: return Vector3.left;
            case 3: return Vector3.right;
            default: return Vector3.forward; //impossible, but C# insists
        }
    }

    private bool CheckMove(Vector3 direction)
    {
        //ghosts cant teleport
        if ((direction + transform.position).x < -12) return false;
        if ((direction + transform.position).x > 8) return false;

        Ray r = new Ray(transform.position + Vector3.down * .25f, direction);
        int layerMask = LayerMask.GetMask("Wall");
        if (Physics.Raycast(r, out RaycastHit hitInfo, .75f, layerMask))
        {
            return false;
        }
        else return true;
    }

    private void DoMove(float yAngle, Vector3 moveVector)
    {
        moving = true;
        transform.localEulerAngles = new Vector3(0f, yAngle, 0f);
        transform.DOMove(position + moveVector, speed).SetEase(Ease.Linear).OnComplete(() => moving = false);
        position += moveVector;
    }

    public void SetModeToPowerPill()
    {
        if (mode == 0) mode = 1;
        DOVirtual.DelayedCall(8f, () => PowerPillExpires());
    }

    private void PowerPillExpires()
    {
        if (mode == 1) mode = 0;
        OriginalColours();
    }

    private void OriginalColours()
    {
        foreach (GameObject g in hideablePartsWhenEaten)
        {
            g.GetComponent<Renderer>().material.color = originalColor;
        }
    }

    public GameObject[] hideablePartsWhenEaten;
    public void Eaten()
    {
        mode = 2;
        foreach (GameObject g in hideablePartsWhenEaten) g.SetActive(false);
        transform.DOMove(new Vector3(-2, 0, 6), 6f).OnComplete(() => Rejuvenate());
    }
    public void Rejuvenate()
    {
        mode = 0;
        position = new Vector3(-2, 0, 6);
        OriginalColours();
        foreach (GameObject g in hideablePartsWhenEaten) g.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EndGame.instance.finished) return;

        if (other.gameObject.name=="PacMan")
        {
            if (mode == 0 )
            {
                LivesHandler.instance.LoseLife();
            }
            else if (mode == 1)
            {
                Scorer.instance.AddScore(1000);
                Eaten();
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
