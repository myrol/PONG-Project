using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;

    [SerializeField] private Goal _p1Goal, _p2Goal;
    [SerializeField] private GameObject _p1, _p2, _ball;
    [SerializeField] private bool verbose = false;

    // ranges from -3 to 3, where -3 indicates that red won and 3 indicates that blue won
    public int advantage = 0;

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

    public void P1Advances()
    {
        advantage++; Verbose("P1 advances!");

        if (advantage >= 3)
        {
            MatchManager.Instance.P1WonRound(); Verbose("P1 Won the round!");
            return;
        }

        _p1Goal.advance();
        _p2Goal.retreat();

        repositionPlayers();
    }

    public void P2Advances()
    {
        advantage--; Verbose("P2 advances!");
        if (advantage <= -3)
        {
            MatchManager.Instance.P2WonRound(); Verbose("P2 Won the round!");
            return;
        }

        _p2Goal.advance();
        _p1Goal.retreat();

        repositionPlayers();
    }

    public void Reset()
    {
        advantage = 0;
        _p1Goal.ResetPosition();
        _p2Goal.ResetPosition();
        repositionPlayers();
    }

    private void repositionPlayers()
    {
        _p1.transform.position = _p1Goal.transform.position + Vector3.right;
        _p2.transform.position = _p2Goal.transform.position + Vector3.left;

        Verbose("Resetting Ball position..." + _ball.transform.position);
        _ball.transform.position = _p1Goal.transform.position + Vector3.right * 10.5f;
        Verbose("Ball position: " + _ball.transform.position);
    }

    private void Verbose(string debugText)
    {
        if (!verbose) return;
        Debug.Log("[DEBUG RoundManager] " + debugText);
    }
}
