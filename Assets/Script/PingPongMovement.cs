using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float speed = 2f;                
    public float moveDistance = 4f;        

    private Vector3 startPosition;         
    private bool movingRight = false;      
    SpriteRenderer sprite;

    void Start()
    {
        startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPosition.x)
            {
                movingRight = false; 
                sprite.flipX = false; 
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;  
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; 
                sprite.flipX = true; 
            }
        }
    }
}
