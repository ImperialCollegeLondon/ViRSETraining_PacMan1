using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public UnityEngine.UI.Image panelImage;
    public GameObject gameOver;
    public GameObject levelCleared;
    public TMPro.TMP_Text scoreText;
    public static EndGame instance;

    public bool finished = false;
    private void Awake()
    {
        instance = this;
    }
    public void GameOver(int finalScore)
    {
        ShowPanel();
        scoreText.text = $"Final Score: {finalScore}";
        DOVirtual.DelayedCall(3f, () => gameOver.SetActive(true));
        DOVirtual.DelayedCall(4.5f, () => ShowScore());
    }
    public void LevelCleared(int finalScore)
    {
        ShowPanel();
        scoreText.text = $"Final Score: {finalScore}";
        DOVirtual.DelayedCall(3f, () => levelCleared.SetActive(true));
        DOVirtual.DelayedCall(4.5f, () => ShowScore());
        finished = true;
    }

    private void ShowScore()
    {
        scoreText.gameObject.SetActive(true);
    }

    private void ShowPanel()
    {
        panelImage.enabled = true;
        panelImage.DOColor(new Color(.42f, .8f, 1f, .8f), 2f);
    }
}
