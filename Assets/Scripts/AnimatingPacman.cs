using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingPacman : MonoBehaviour
{
    public float MouthSpeed;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += MouthSpeed * Controller.instance.currentDirection.magnitude;
        transform.localEulerAngles = new Vector3(0f, 140 + Mathf.Sin(time)*40, 0f);
    }
}
