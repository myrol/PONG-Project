using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 4f;

    private Vector2 velocity;

    // Movement
    private void Update()
    {
        // Movement
        velocity = getInputDirection() * _speed; // Fetch Player Input
        _rigidbody.velocity = velocity; // Apply to rigidbody
    }

    private Vector2 getInputDirection()
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
