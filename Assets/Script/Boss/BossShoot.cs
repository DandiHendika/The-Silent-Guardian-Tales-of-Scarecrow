using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public float bulletSpeed = 10f; 
    private SpriteRenderer sprite;  
    private Animator anim;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && cooldownTimer > attackCooldown) 
        {
            anim.SetTrigger("Attack");
        }
        cooldownTimer += Time.deltaTime;
    }

    void Shoot()
    {
        
        cooldownTimer = 0;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 shootDirection = sprite.flipX ? Vector2.left : Vector2.right; 
            rb.velocity = shootDirection * bulletSpeed;
        }
              
        Destroy(bullet, 2f);
    }
}


