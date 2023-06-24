using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public static Scorer instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private int totalScore = 0;
    public void AddScore(int score)
    {
        totalScore += score;
        GetComponent<TMP_Text>().text = $"Score:\n{totalScore}";
    }

    public GhostMovement[] ghosts;
    public void StartPowerPill()
    {
        foreach (var g in  ghosts) { g.SetModeToPowerPill(); }
    }

    public AudioSource chomp, powerpill;
    public void PlaySoundChomp()
    {
        chomp.Play();
    }

    public void PlaySoundPowerPill()
    {
        powerpill.Play();
    }

    internal int GetScore()
    {
        return totalScore;
    }

    int pillcount = 0;
    int pillCountToWin = 0;
    public void IncPillCount()
    {
        pillcount++;
        
        if (pillcount==pillCountToWin)
        {
            EndGame.instance.LevelCleared(totalScore);
        }
    }

    internal void RegisterPill()
    {
        pillCountToWin++;
    }
}
