using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] private Transform[] goalPositions;
    [SerializeField] private bool _isLeftGoal = true;
    
    /*
     * Initial Starting positions:
           B  |  R
       0 1 2 3 4 5 6 7 
    */
    private int currentGoalPosition;

    private void Awake()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        currentGoalPosition = (_isLeftGoal) ? 2 : 5;
        updatePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag != "Ball") return;

        if (_isLeftGoal)
        {
            RoundManager.Instance.P2Advances();
        }
        else
        {
            RoundManager.Instance.P1Advances();
        }
    }

    public void advance()
    {
        currentGoalPosition = (_isLeftGoal) ? currentGoalPosition + 1 : currentGoalPosition - 1;
        updatePosition();
    }

    public void retreat()
    {
        currentGoalPosition = (_isLeftGoal) ? currentGoalPosition - 1 : currentGoalPosition + 1;
        updatePosition();
    }

    private void updatePosition()
    {
        transform.position = goalPositions[currentGoalPosition].position;
        transform.rotation = goalPositions[currentGoalPosition].rotation;
    }
}
