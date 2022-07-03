using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _speed = 5f;

    private Vector2 velocity;

    void Start()
    {
        resetPosition();
        chooseRandomDirection();
    }

    /*
     * Respawn at the predetermined spawnlocation and choose a new direction to fly in. 
     */
    public void resetPosition()
    {
        transform.position = _spawnPosition.position;
    }

    /*
     * Choose a random direction to fly in.
     */
    public void chooseRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;

        velocity = direction * _speed;
    }

    public void redirect(Vector2 newDirection)
    {
        velocity = newDirection.normalized;
    }

    public Vector2 getVelocity()
    {
        return velocity;
    }
}
