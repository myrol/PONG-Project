using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] public float _cooldownDuration;
    [SerializeField] public Camera _camera;

    private bool canUseAbility = true;

    protected abstract void Execute();

    protected void Activate()
    {
        if (!canUseAbility) return;

        Execute();
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        canUseAbility = false;
        yield return new WaitForSeconds(_cooldownDuration);
        canUseAbility = true;
    }

    protected Vector2 GetMouseDirection()
    {
        // Calculate the direction to direct the ball to
        Vector3 mouseToWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseToWorldPosition - transform.position).normalized;

        return direction;
    }

    protected Vector2 GetMousePosition()
    {
        Vector3 mouseToWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        return mouseToWorldPosition;
    }

    protected Vector2 GetInputDirection()
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