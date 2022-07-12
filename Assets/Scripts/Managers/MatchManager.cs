using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;
    public const int WINNER_P1 = 1;
    public const int WINNER_P2 = 2;

    [SerializeField] private bool verbose = false;
    // First to score this many rounds for themselves wins the match
    [SerializeField] private byte winCondition = 2;

    //1 if it's blue, 2 if it's red
    private int winner = 0;
    private byte scoreP1 = 0;
    private byte scoreP2 = 0;

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
    }

    public void P1WonRound()
    {
        scoreP1++;

        if (scoreP1 >= winCondition)
        {
            SetWinner(WINNER_P1);
        }

        RoundManager.Instance.Reset();
        ScoreDisplayManager.Instance.P1Scored();
    }
    public void P2WonRound()
    {
        scoreP2++;

        if (scoreP2 >= winCondition)
        {
            SetWinner(WINNER_P2);
        }
        
        RoundManager.Instance.Reset();
        ScoreDisplayManager.Instance.P2Scored();
    }

    /**
     * Sets the winner. If it's an undefined winner, it sets winner to -1.
     */
    private void SetWinner(int _winner)
    {
        winner = (_winner == WINNER_P1 || _winner == WINNER_P2) ? _winner : -1; 
        Verbose("Winner is " + winner); // DEBUG

        // Set the Score to display the winner
        ScoreDisplayManager.Instance.display.text = (winner == WINNER_P1) ? "P1 Won!" : "P2 Won!";
    }

    /**
     * Resets the whole Match
     */
    public void Reset()
    {
        winner = 0;
        RoundManager.Instance.Reset();
        ScoreDisplayManager.Instance.Reset();
    }

    /**
     * Sets the Match configuration to "First to get <_winCondition> points"
     */
    private void SetMatchType(byte _winCondition)
    {
        winCondition = _winCondition;
    }

    private void Verbose(string _debugText)
    {
        if (!verbose) return;
        Debug.Log("[DEBUG MatchManager] " + _debugText);
    }
}
