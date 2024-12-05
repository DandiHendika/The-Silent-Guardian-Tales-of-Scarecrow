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
        Bosscontrollers boss = collision.GetComponent<Bosscontrollers>();
        if (enemy != null)
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            // Berikan damage pada musuh
            enemy.TakeDamage(damage);

            // Hancurkan peluru setelah tabrakan
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            // Hancurkan peluru setelah mengenai ground
            Destroy(gameObject);
        }
        if (boss != null)
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            // Berikan damage pada musuh
            boss.TakeDamage(damage);

            // Hancurkan peluru setelah tabrakan
            Destroy(gameObject);
        }
    }
}


