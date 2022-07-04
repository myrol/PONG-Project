using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dash : Ability
{
    [SerializeField] private float _force = 10f;

    private Rigidbody2D player_rigidbody;
    private PlayerMovement player_controls;

    private void Awake()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
        player_controls = GetComponent<PlayerMovement>();
    }

    protected override void Execute()
    {
        StartCoroutine(pushBy(_force));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Activate();
        }
    }

    /*
     * Adds a small force on the player, which slows down
     * to its original value over two seconds
     */
    private IEnumerator pushBy(float value)
    {
        player_controls.enabled = false;
        player_rigidbody.AddForce(GetInputDirection() * value);

        yield return new WaitForSeconds(.25f);

        player_controls.enabled = true;
    }
}
