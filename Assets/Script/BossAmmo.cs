using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAmmo : MonoBehaviour
{
    public float speed = 5f; 
    public int damage = 1; 
    public float lifeTime = 5f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Health targetHealth = other.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }
}

