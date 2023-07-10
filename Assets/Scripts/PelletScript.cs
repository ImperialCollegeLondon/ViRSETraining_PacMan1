using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pellet : MonoBehaviour
{

    public int score = 10;
    private bool isPowerPellet;
    private Vector3 scaleChange;

    private int frames;
    void Awake()
    {
        frames = 0;
        isPowerPellet = this.tag == "PowerPellet";
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

    }

    void Start()
    {
        GameManager.instance.incrementPelletCount();
    }

    private void FixedUpdate()
    {
        if (isPowerPellet)
        {
            
            transform.localScale += scaleChange;
            frames++;
            if (frames == 25)
            {
                transform.localScale *= -1;
                frames = 0;
            }
        }
    }

    protected virtual void Eat()
    {
        if (isPowerPellet)
        {
            GameManager.instance.eatPowerPellet(this);
        }
        else {
            GameManager.instance.eatPellet(this);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Eat();
        }
    }
}