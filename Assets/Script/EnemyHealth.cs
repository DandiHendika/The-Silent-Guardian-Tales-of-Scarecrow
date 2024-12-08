using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;       
    private int currentHealth;      
    private Animator animator;       
    public float destroyDelay = 1f; 

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {     
        animator.SetTrigger("Die");
        SoundManager.Instance.PlaySound2D("enemykill");
        
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }     
        Destroy(gameObject, destroyDelay);
    }
}

