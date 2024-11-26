using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAmmo : MonoBehaviour
{
    public float speed = 5f; // Kecepatan proyektil
    public int damage = 1; // Damage yang diberikan
    public float lifeTime = 5f; // Waktu hidup proyektil

    void Start()
    {
        // Hancurkan proyektil setelah waktu tertentu
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Gerakan proyektil ke arah kanan
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

