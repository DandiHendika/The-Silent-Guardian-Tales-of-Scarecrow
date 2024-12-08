using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        Bosscontrollers boss = collision.GetComponent<Bosscontrollers>();
        if (enemy != null)
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            Destroy(gameObject);
        }
        if (boss != null)
        {
            SoundManager.Instance.PlaySound2D("bullethit");
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}


