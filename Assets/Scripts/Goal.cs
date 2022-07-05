using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool _isLeftGoal = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag != "Ball") return;


    }

    public void advance()
    {

    }

    public void retreat()
    {

    }
}
