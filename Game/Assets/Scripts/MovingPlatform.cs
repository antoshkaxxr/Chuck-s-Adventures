using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float dirX;
    [SerializeField] private float speed;
    private bool movingRight = true;
    
    void Update()
    {
        if (transform.position.x > dirX)
            movingRight = false;
        else if (transform.position.x < -dirX)
            movingRight = true;
        if (movingRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
