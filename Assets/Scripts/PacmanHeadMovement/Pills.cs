using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PacManRoot")
        {
            gameObject.SetActive(false);
            Debug.Log("collide!");
            PacManSound.instance.PlayChomp();
            ScoreController.instance.Score(10);
        }
    }
}
