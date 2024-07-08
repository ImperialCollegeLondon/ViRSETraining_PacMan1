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
    public GameObject fruit;
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(t, () => ChangePowerPill());
        fruit.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), t);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate
        fruit.transform.DORotate(new Vector3(0f, 0.5f * count, 0f), t);
        count++;

        //size
        if (fruit.transform.localScale.x > 1.59f)
        {
            fruit.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), t);
        }
        else if (fruit.transform.localScale.x < 0.71f)
        {
            fruit.transform.DOScale(new Vector3(1.6f, 1.6f, 1.6f), t);
        }
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

    public void ChangePowerPill()
    {
        /*// change size
        if (transform.localScale.x > 0.45)
        {
            fruit.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), t);
        }
        else if (transform.localScale.x < 0.45)
        {
            fruit.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), t);
        }

        if (transform.position.y == 0)
        {
            Vector3 pos = transform.localPosition;
            fruit.transform.DOMove(pos + new Vector3(0f,0.5f * y_shift,0f), t*1f).SetEase(Ease.OutCubic);

        }
        else if (transform.position.y > 0)
        {
            Vector3 pos = transform.localPosition;
            fruit.transform.DOMove(pos + new Vector3(0f, -1f * y_shift, 0f), t * 1f).SetEase(Ease.OutCubic);
        }
        else if (transform.position.y < 0)
        {
            Vector3 pos = transform.localPosition;
            fruit.transform.DOMove(pos + new Vector3(0f,1f * y_shift, 0f), t * 1f).SetEase(Ease.OutCubic);
        }

        DOVirtual.DelayedCall(t, () => ChangePowerPill());*/

    }

}
