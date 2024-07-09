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
    public TMP_Text end_score2;
    public TMP_Text end_board_text2;

    private float current_score = 0;
    private float current_live = 3;

    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;

    public GameObject heart3_w;
    public GameObject heart2_w;
    public GameObject heart1_w;

    public GameObject end_board;
    public GameObject end_board2;
    private int pill_no = 356;
    private bool game_end = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        end_board.SetActive(false);
        end_board2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        add_score.text = ($"{current_score}");
        add_score_world.text = ($"{current_score}");
        //Debug.Log(current_score);

        if (current_live == 2 && game_end == false)
        {
            heart3.SetActive( false );
            heart3_w.SetActive(false);
        }
        if (current_live == 1 && game_end == false)
        {
            heart2.SetActive(false);
            heart2_w.SetActive(false);
        }
        if (current_live == 0 && game_end == false)
        {
            end_board.SetActive(true);
            end_board2.SetActive(true);
            heart1.SetActive(false);
            heart1_w.SetActive(false);
            game_end = true;
            end_score.text = ($"{current_score}");
            end_board_text.text = ("You Lose.");
            end_score2.text = ($"{current_score}");
            end_board_text2.text = ("You Lose.");
        }


        if (pill_no == 0 && game_end == false) 
        {
            end_board.SetActive(true);
            end_board2.SetActive(true);
            game_end = true;
            end_board_text.text = ("You Win!");
            end_score.text = ($"{current_score}");
            end_board_text2.text = ("You Win!");
            end_score2.text = ($"{current_score}");
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

    public void AllPills()
    {
        pill_no--;
    }
}
