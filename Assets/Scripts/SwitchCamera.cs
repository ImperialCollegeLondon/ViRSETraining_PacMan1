using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    public GameObject wideAngle;
    public GameObject firstPerson;
    private bool changedAngle = false;      // has angle been changed from initial settings (first person on, main off)

    public void SwitchCameraAngle()
    {
        if (changedAngle)
        {
            firstPerson.SetActive(true);
            wideAngle.SetActive(false);
            changedAngle = false;

        }
        else
        {
            firstPerson.SetActive(false);
            wideAngle.SetActive(true);
            changedAngle = true;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        firstPerson.SetActive(true);
        wideAngle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCameraAngle();
        }
    }
}
