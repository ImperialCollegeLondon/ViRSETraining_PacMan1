using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.XR;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class Modes : MonoBehaviour
{
    //Mode 1: Normal
    //Mode 2: Powerpill
    //Mode 3: Eyes returned


    public GameObject head;
    public GameObject cylinder;
    public GameObject leg1;
    public GameObject leg2;
    public GameObject leg3;

    public GameObject ghost;
    public GhostMovement ghostMovement;
    private float timer = 0f;
    public bool useColor1 = true;
    public Color color1;

    private int lastMode = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lastMode != ghostMovement.mode)
        {
            if (ghostMovement.mode == 3)
            {
                EyesReturn();
            }
        }
        if (ghostMovement.mode == 2)
        {
            PowerPillMode(PowerPillEatenTime.instance.eatenTime);
        }
        lastMode = ghostMovement.mode;

    }
    private void PowerPillMode(float time)
    {
        if (time + 5f > Time.time)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                timer = 0.0f;
                useColor1 = !useColor1;
                head.GetComponent<MeshRenderer>().material.color = useColor1 ? Color.blue : color1;
                cylinder.GetComponent<MeshRenderer>().material.color = useColor1 ? Color.blue : color1;
                leg1.GetComponent<MeshRenderer>().material.color = useColor1 ? Color.blue : color1;
                leg2.GetComponent<MeshRenderer>().material.color = useColor1 ? Color.blue : color1;
                leg3.GetComponent<MeshRenderer>().material.color = useColor1 ? Color.blue : color1;
            }
        }
        else
        {
            ghostMovement.mode = 1;
            head.GetComponent<MeshRenderer>().material.color = color1;
            cylinder.GetComponent<MeshRenderer>().material.color = color1;
            leg1.GetComponent<MeshRenderer>().material.color = color1;
            leg2.GetComponent<MeshRenderer>().material.color = color1;
            leg3.GetComponent<MeshRenderer>().material.color = color1;
        }
    }
    private void EyesReturn()
    {
        foreach (Transform child in ghost.transform)
            if (child.name == "LeftEye" || child.name == "RIghtEye")
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }

        ghost.transform.DOMove(new Vector3(0, 0.5f, 0),2f).OnComplete(() => GhostReturned());

    }
    private void GhostReturned()
    {
        foreach (Transform child in ghost.transform)
            child.gameObject.SetActive(true);
        
        ghostMovement.mode = 1;

    }
}
