using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public static ScoreController instance;
    public TMP_Text add_score;
    public TMP_Text add_score_world;
    public TMP_Text end_score;
    public TMP_Text end_board_text;

    private float current_score = 0;
    private float current_live = 3;

    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;

    public GameObject heart3_w;
    public GameObject heart2_w;
    public GameObject heart1_w;

    public GameObject end_board;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //end_board.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        add_score.text = ($"{current_score}");
        add_score_world.text = ($"{current_score}");
        //Debug.Log(current_score);

        if (current_live == 2)
        {
            heart3.SetActive( false );
            heart3_w.SetActive(false);
        }
        if (current_live == 1)
        {
            heart2.SetActive(false);
            heart2_w.SetActive(false);
        }
        if (current_live == 0)
        {
            end_board.SetActive(true);
            heart1.SetActive(false);
            heart1_w.SetActive(false);
            end_score.text = ($"{current_score}");
            end_board_text.text = ("You Lose");
        }

    }

    public void Score(float score)
    {
        current_score += score;
    }

    public void Lives()
    {
        current_live--;
    }
}
