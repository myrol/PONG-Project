using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;

    [SerializeField] private Goal _p1Goal, _p2Goal;
    [SerializeField] private GameObject _p1, _p2;

    // ranges from -3 to 3, where -3 indicates that red won and 3 indicates that blue won
    private int advantage = 0;

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
        _p1Goal.advance();
        _p2Goal.retreat();

        repositionPlayers();
    }

    public void P2Advances()
    {
        _p2Goal.advance();
        _p1Goal.retreat();

        repositionPlayers();
    }

    private void repositionPlayers()
    {
        _p1.transform.position = _p1Goal.transform.position + Vector3.right;
        _p2.transform.position = _p2Goal.transform.position + Vector3.left;
    }
}
