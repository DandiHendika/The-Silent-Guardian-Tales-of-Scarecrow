using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed ;       
    public float moveDistance; 
    private Vector3 startPosition;   
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }

}
