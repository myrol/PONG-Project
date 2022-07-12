using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * This class Manages the Score of a Game.
 * A player scores, when it gets its opponent to be in the last section when scoring a ball.
 */
public class ScoreDisplayManager : MonoBehaviour
{
    public static ScoreDisplayManager Instance;
    public TextMeshPro display;

    private byte p1_score = 0, p2_score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        Reset();
    }

    public void Reset()
    {
        p1_score = 0; 
        p2_score = 0;
    }

    public void P1Scored()
    {
        p1_score++;
        UpdateDisplay();
    }

    public void P2Scored()
    {
        p2_score++;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        display.text = p1_score + " : " + p2_score;
    }
}
