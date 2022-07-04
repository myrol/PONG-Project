using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This Script is responsible for redirecting the ball 
 * if the ball is in the vicinity of the player and 
 * if the player pressed the corresponding button.
 */
public class PlayerRedirect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool verbose = false;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _force = 9f;

    private bool canRedirect = true;
    private Ball ball;

    /*
     * If the ball enters the trigger, the flag should be set to 1.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag != "Ball") return; // Guard Clause for if it's not the ball

        ball = collider.GetComponent<Ball>();
    }

    /*
     * If the ball leaves the trigger, the flag should be set to 0.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag != "Ball") return; // Guard Clause for if it's not the ball

        ball = null;
    }

    private void Update()
    {
        // Guard Clause for if the ball is not in range
        if (ball == null || !canRedirect) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Calculate the direction to direct the ball to
            Vector3 mouseToWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mouseToWorldPosition - transform.position).normalized;

            Verbose("mouseToWorldPosition: " + mouseToWorldPosition);
            Verbose("direction: " + direction);

            ball.redirect(direction);
            ball.pushBy(_force); // Applies a small force to the ball (decays over time)

            StartCoroutine(Cooldown()); // The player cannot redirect for a short period of time
        }
    }

    private IEnumerator Cooldown()
    {
        canRedirect = false;    Verbose("Redirect on cooldown...");
        yield return new WaitForSeconds(_cooldown);
        canRedirect = true;     Verbose("Redirect back up");
    }

    private void Verbose(string s)
    {
        if (verbose) Debug.Log("[DEBUG PlayerRedirect] " + s);
    }
}
