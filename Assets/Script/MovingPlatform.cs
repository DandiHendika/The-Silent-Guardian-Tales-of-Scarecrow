using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2f; 

    private Vector3 targetPosition; 

    void Start()
    {
        
        targetPosition = pointA.position;
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null); 
        }
    }

}
