using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireblast : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter2D(Collision2D other)
    {
        Health targetHealth = other.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }
}

