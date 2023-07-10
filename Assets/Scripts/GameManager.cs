using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {
    public Transform pellets;
    [SerializeField]
    public GameObject pellet;

    private int score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void eatPowerPellet(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        score += pellet.score;
        Debug.Log("Power Pellet eaten");
    }

    public void eatPellet(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        score += pellet.score;
        Debug.Log("Pellet eaten");

        if (!pelletsLeft())
        {
            Debug.Log("All pellets have been eaten");
        }
    }

    private bool pelletsLeft()
    {
        foreach (Transform pellet in pellets) {
            if  (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
