using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pellet : MonoBehaviour
{

    public int score = 10;
    private bool isPowerPellet = false;
    void Awake()
    {

    }

    protected virtual void Eat()
    {
        if (isPowerPellet)
        {
            // Call Power Pellet Script
            FindObjectOfType<GameManager>().eatPowerPellet(this);
        }
        else {
            FindObjectOfType<GameManager>().eatPellet(this);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pellet has been collided with");
        // Update to layer of Pacman
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}