using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public static ScoreController instance;
    public TMP_Text add_score;
    public TMP_Text add_score_world;

    private float current_score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        add_score.text = ($"{current_score}");
        add_score_world.text = ($"{current_score}");
        //Debug.Log(current_score);

    }

    public void Score(float score)
    {
        current_score += score;
    }
}
