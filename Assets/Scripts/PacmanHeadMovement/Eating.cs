using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting.ReorderableList;
using TMPro;

public class Eating : MonoBehaviour
{
    public GameObject jaw;
    public GameObject head;
    public bool playing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void HeadCycle()
    {
        head.transform.DOLocalRotate(new Vector3(260f, 0f, 0f), .3f).OnComplete(() => head.transform.DOLocalRotate(new Vector3(240f, 0f, 0f), .3f).OnComplete(() => HeadCycle()));
    }

    private void JawCycle()
    {
        jaw.transform.DOLocalRotate(new Vector3(90, 0f, 0f), .3f).OnComplete(() => jaw.transform.DOLocalRotate(new Vector3(110, 0f, 0f), .3f).OnComplete(() => JawCycle()));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayAnimation(true);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(false);
        }
    }
    public void PlayAnimation(bool play)
    {

        if ( (play==playing) )
        {
            return;
        }

        if (play)
        {
            HeadCycle();
            JawCycle();
        }
        else
        {
            head.transform.DOKill();
            jaw.transform.DOKill();
        }
        playing = play;
    }
}
