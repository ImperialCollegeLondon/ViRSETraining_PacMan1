using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlate : MonoBehaviour
{
    public GameObject[] boards;
    public GameObject screenboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < boards.Length; i++)
        {
            boards[i].GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, 1));
        }
        screenboard.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.grey, Mathf.PingPong(Time.time, 1));
    }
}
