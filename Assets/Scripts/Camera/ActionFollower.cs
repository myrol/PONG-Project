using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFollower : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToFollow;

    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        float center = (getMostLeft() + getMostRight()) / 2;

        transform.position = new Vector3(center, 0f, -10f);
    }

    private float getMostLeft()
    {
        float mostLeft = 0f;
        foreach (GameObject g in objectsToFollow)
        {
            float g_x = g.transform.position.x;
            if (g_x < mostLeft)
            {
                mostLeft = g_x;
            }
        }

        return mostLeft;
    }

    private float getMostRight()
    {
        float mostRight = 0f;
        foreach (GameObject g in objectsToFollow)
        {
            float g_x = g.transform.position.x;
            if (g_x > mostRight)
            {
                mostRight = g_x;
            }
        }

        return mostRight;
    }
}
