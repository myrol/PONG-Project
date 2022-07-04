using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] public float _speed = 4f;

    private Vector2 velocity;

    public bool isInControl = true;

    // Movement
    private void Update()
    {
        if (!isInControl) return;

        // Movement
        velocity = GetInputDirection() * _speed; // Fetch Player Input
        _rigidbody.velocity = velocity; // Apply to rigidbody
    }

    public Vector2 GetInputDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        return direction.normalized;
    }
}
