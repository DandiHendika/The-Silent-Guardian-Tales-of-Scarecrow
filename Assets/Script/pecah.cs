using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Animator animator; 
    public float destroyDelay = 1f; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerBreak();  
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            TriggerBreak(); 
        }
    }

    void TriggerBreak()
    {
        animator.SetTrigger("pecah"); 
        Destroy(gameObject, destroyDelay);
    }
}
