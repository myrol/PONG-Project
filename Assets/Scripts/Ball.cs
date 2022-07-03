using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private bool verbose = false;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _speed = 5f;

    private Vector2 velocity;

    void Start()
    {
        resetPosition();
        chooseRandomDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = velocity;
    }

    /*
     * If colliding with a wall, reflect accordingly
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag != "Reflect") return;

        Verbose("Before collision with wall: " + velocity.normalized + " + " + collision.contacts[0].normal);
        redirect(Vector2.Reflect(velocity, collision.contacts[0].normal));
    }

    /*
     * Respawn at the predetermined spawnlocation and choose a new direction to fly in. 
     */
    public void resetPosition()
    {
        transform.position = _spawnPosition.position;
        Verbose("Respawned.");
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

        Verbose("Chose a new random direction to fly in: " + velocity);
    }

    /*
     * Redirect the ball to a new direction
     */
    public void redirect(Vector2 newDirection)
    {
        velocity = newDirection.normalized * _speed;
        Verbose("Redirected with velocity " + newDirection);
    }

    public Vector2 getVelocity()
    {
        return velocity;
    }

    private void Verbose(string s)
    {
        if (verbose) Debug.Log("[DEBUG Ball] " + s);
    }
}
