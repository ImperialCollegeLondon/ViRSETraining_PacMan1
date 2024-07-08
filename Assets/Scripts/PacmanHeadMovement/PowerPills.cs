using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PowerPills : MonoBehaviour
{
    public bool power = false;
    public float speed_rotate;
    public float speed_size;
    private bool size_up = true;
    public float y_shift;

    public GameObject fruit;
    // Start is called before the first frame update
    void Start()
    {

        //DOVirtual.DelayedCall(t, () => ChangePowerPill());
        //fruit.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), t);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate
        fruit.transform.Rotate(0f, 1f * speed_rotate, 0f, Space.Self);

        //size up and down
        if (fruit.transform.localScale.x > 1.59f)
        {
            size_up = false;
        }
        else if (fruit.transform.localScale.x < 0.71f)
        {
            size_up = true;
        }

        if (size_up == false)
        {
            fruit.transform.localScale += new Vector3(-1f * speed_size, -1f * speed_size, -1f * speed_size);
        }
        else if (size_up == true)
        {
            fruit.transform.localScale += new Vector3(1f * speed_size, 1f * speed_size, 1f * speed_size);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PacManRoot")
        {
            fruit.SetActive(false);
            Debug.Log("PowerPill collide!");
            power = true;
            PowerPillEatenTime.instance.eatenTime = Time.time;
            foreach (GameObject ghost in PowerPillEatenTime.instance.ghosts)
            {
                if (ghost.GetComponent<GhostMovement>().mode == 1)
                {
                    ghost.GetComponent<GhostMovement>().mode = 2;
                }
            }
            //PacManSound.instance.PlayChomp();
        }
    }

}
