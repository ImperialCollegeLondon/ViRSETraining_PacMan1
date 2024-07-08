using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPillEatenTime : MonoBehaviour
{
    public float eatenTime = -1;
    public static PowerPillEatenTime instance;
    public GameObject[] ghosts;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    

}
