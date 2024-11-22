using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Besar damage peluru

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek jika yang terkena peluru adalah musuh
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            // Berikan damage pada musuh
            enemy.TakeDamage(damage);

            // Hancurkan peluru setelah tabrakan
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            // Hancurkan peluru setelah mengenai ground
            Destroy(gameObject);
        }
    }
}


