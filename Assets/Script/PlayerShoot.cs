using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab peluru
    public Transform firePoint;     // Titik tembak
    public float bulletSpeed = 10f; // Kecepatan peluru
    private SpriteRenderer sprite;  // Sprite player untuk menentukan arah
    private Animator anim;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    private bool isattacking = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C) && cooldownTimer > attackCooldown && !isattacking) // Tombol untuk menembak
        {
            SoundManager.Instance.PlaySound2D("Shoot");
            anim.SetTrigger("Attack");
            isattacking = true;
        }
        cooldownTimer += Time.deltaTime;
    }

    void Shoot()
    {
        // Membuat peluru di posisi firePoint
        cooldownTimer = 0;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Menentukan arah peluru
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 shootDirection = sprite.flipX ? Vector2.left : Vector2.right; // Kiri jika flipX
            rb.velocity = shootDirection * bulletSpeed;
        }

        // Hancurkan peluru setelah beberapa detik
        Destroy(bullet, 2f);
    }

    public void EndAttack()
    {
        isattacking = false; // Mengizinkan input ulang setelah animasi selesai
    }
}


