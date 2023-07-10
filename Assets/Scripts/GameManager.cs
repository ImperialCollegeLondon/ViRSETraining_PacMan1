using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private int pelletsLeft;
    public UIScript scoreScript;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        pelletsLeft = 0;
    }

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
    }

    public void eatPellet(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        score += pellet.score;
        pelletsLeft--;
        
        if (pelletsLeft == 0)
        {
            Debug.Log("All pellets have been eaten");
            Debug.Log("Ending the game");
        }

        scoreScript.AllScores(score);
    }

    public void incrementPelletCount()
    {
        pelletsLeft++;
    }

    private void decrementPelletCount()
    {
        pelletsLeft--;
    }
}
