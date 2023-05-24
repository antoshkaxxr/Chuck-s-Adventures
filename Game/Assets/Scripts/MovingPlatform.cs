using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float leftEdge;
    [SerializeField] private float rightEdge;
    [SerializeField] private float speed;
    private bool movingRight = true;

    private void Update()
    {
        if (transform.position.x > rightEdge)
            movingRight = false;
        else if (transform.position.x < leftEdge)
            movingRight = true;
        if (movingRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
