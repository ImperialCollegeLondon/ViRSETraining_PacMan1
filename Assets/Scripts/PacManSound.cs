using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManSound : MonoBehaviour
{
    public AudioSource chompSound;

    public static PacManSound instance;

    public void PlayChomp()
    {
        chompSound.Play();
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
