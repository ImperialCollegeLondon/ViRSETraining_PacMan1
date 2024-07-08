using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PowerPills : MonoBehaviour
{
    public bool power = false;
    public float t;
    private float count = 1;
    public float y_shift;
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(t, () => ChangePowerPill());
    }

    // Update is called once per frame
    void Update()
    {
        //rotate
        transform.DORotate(new Vector3(0f, 0.5f * count, 0f), t);
        count++;

        /*//size
        if (transform.localScale.x == 0.6f)
        {
            transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), t*0.5f);
        }
        else if (transform.localScale.x == 0.3f)
        {
            transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), t * 0.5f);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PacManRoot")
        {
            gameObject.SetActive(false);
            Debug.Log("PowerPill collide!");
            power = true;
        }
    }
    /*void ColorChanger()
    {
        if (this.tag == "Barrier")
        {
            if (transform.position.y <= -9)
            {
                Color.Lerp(Color.green, Color.red, 1.5f);
            }

            if (transform.position.y >= -6)
            {
                Color.Lerp(Color.red, Color.green, 1.5f);
            }
        }
    }*/

    public void ChangePowerPill()
    {
        // change size
        if (transform.localScale.x > 0.45)
        {
            transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), t);
        }
        else if (transform.localScale.x < 0.45)
        {
            transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), t);
        }

        if (transform.position.y == 0)
        {
            Vector3 pos = transform.localPosition;
            transform.DOMove(pos + new Vector3(0f,0.5f * y_shift,0f), t*1f).SetEase(Ease.OutCubic);

        }
        else if (transform.position.y > 0)
        {
            Vector3 pos = transform.localPosition;
            transform.DOMove(pos + new Vector3(0f, -1f * y_shift, 0f), t * 1f).SetEase(Ease.OutCubic);
        }
        else if (transform.position.y < 0)
        {
            Vector3 pos = transform.localPosition;
            transform.DOMove(pos + new Vector3(0f,1f * y_shift, 0f), t * 1f).SetEase(Ease.OutCubic);
        }

        DOVirtual.DelayedCall(t, () => ChangePowerPill());

    }

}
