using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingPacman : MonoBehaviour
{
    public int MouthSpeed=3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) )
        {
            Debug.Log("in loop");
            gameObject.transform.localEulerAngles = new Vector3(0f, 160 + Mathf.Sin(Time.time*MouthSpeed)*40, 0f);
        }
    }
}
