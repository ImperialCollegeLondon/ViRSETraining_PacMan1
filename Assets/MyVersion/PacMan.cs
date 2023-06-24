using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PacMan : MonoBehaviour
{
    private Vector3 position = Vector3.zero;

    public bool moving = false;
    public float speed = .5f;
    public float animSpeed = 6f;
    public GameObject upperPart, lowerPart;

    private bool dying = false;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        
        if (!moving && !dying && !EndGame.instance.finished)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (CheckMove(Vector3.right))
                DoMove(90f, Vector3.right);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (CheckMove(Vector3.left))
                    DoMove(-90f, Vector3.left);
            }
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                if (CheckMove(Vector3.forward))
                    DoMove(0f, Vector3.forward);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                if(CheckMove(Vector3.back))
                    DoMove(180f, Vector3.back);
            }
        }

        float animPhase = Mathf.Sin((transform.position.x + transform.position.z) * animSpeed);
        if (!dying) Animate(animPhase);

        if (transform.position.x> 8.0001f)
        {
            transform.DOKill();
            transform.position = transform.position + Vector3.left * 20f;
            position += Vector3.left * 20f;
            transform.DOMove(position, speed).SetEase(Ease.Linear).OnComplete(() => moving = false);
        }

        if (transform.position.x < -12.0001f)
        {
            transform.DOKill();
            transform.position = transform.position + Vector3.right * 20f;
            position += Vector3.right * 20f;
            transform.DOMove(position, speed).SetEase(Ease.Linear).OnComplete(() => moving = false);
        }

    }

    public void Kill()
    {
        dying = true;
        transform.DOKill();
        transform.DOMove(transform.position + Vector3.down, 2f);

    }

    public void Reset()
    {
        dying = false;
        transform.position = startPosition;
        transform.rotation = startRotation; 
        position = Vector3.zero;
        moving = false;
    }

    private bool CheckMove(Vector3 direction)
    {
        Ray r = new Ray(transform.position + Vector3.down * .25f, direction);
        int layerMask = LayerMask.GetMask("Wall");
        if (Physics.Raycast(r, out RaycastHit hitInfo, .75f, layerMask))
        {
            return false;
        }
        else return true;
    }

    private void Animate(float animPhase)
    {
        //range of x is -90 to -120
        upperPart.transform.localEulerAngles = new Vector3(animPhase * 15f - 105f, 0f, 0f);
        lowerPart.transform.localEulerAngles = new Vector3(animPhase * 15f + 75f, 180f, 0f);
    }

    private void DoMove(float yAngle, Vector3 moveVector)
    {
        moving = true;
        transform.localEulerAngles = new Vector3(0f, yAngle, 0f);
        transform.DOMove(position + moveVector, speed).SetEase(Ease.Linear).OnComplete(() => moving = false);
        position += moveVector;
    }

    internal bool IsDying()
    {
        return dying;
    }
}
