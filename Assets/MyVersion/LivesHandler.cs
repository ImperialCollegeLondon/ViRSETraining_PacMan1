using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesHandler : MonoBehaviour
{
    public static LivesHandler instance;
    public PacMan pacMan;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    int lives = 3;
    public void LoseLife()
    {
        if (!pacMan.IsDying())
        {
            lives--;
            pacMan.Kill();
            GetComponent<AudioSource>().Play();
            GetComponent<TMP_Text>().text = $"Lives:\n{lives}";
            if (lives == 0)
            {
                EndGame.instance.GameOver(Scorer.instance.GetScore());
            }
            else
            {
                DOVirtual.DelayedCall(4f, () => pacMan.Reset());
            }
        }
    }
}
