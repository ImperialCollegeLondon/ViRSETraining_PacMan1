using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject pellets;
    public GameObject magicPills;
    public GameObject pacMan;
    public List<GameObject> ghostList;

    public TMP_Text score;

    private int addingScore = 0;

    void Start()
    {
        score.text = "0";
    }
    public void AllScores(int scores)
    {
        addingScore += scores;
        score.text = $"{addingScore}";
    }
}
