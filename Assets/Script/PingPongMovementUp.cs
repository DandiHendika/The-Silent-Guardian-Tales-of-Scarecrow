using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovementUp : MonoBehaviour
{
    public float speed = 2f;                
    public float moveDistance = 4f;        

    private Vector3 startPosition;         
    private bool movingUp = true;          


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false; 
            }
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= startPosition.y)
            {
                movingUp = true; 
            }
        }
    }
}

