using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pellet : MonoBehaviour
{

    public int score = 10;
    void Awake()
    {

    }

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().eatPellet(this);
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