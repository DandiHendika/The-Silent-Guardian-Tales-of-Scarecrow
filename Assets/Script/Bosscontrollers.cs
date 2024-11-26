using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosscontrollers : MonoBehaviour
{
    public int maxHealth = 3; // Nyawa boss
    public int currentHealth;
    public GameObject projectilePrefab; // Prefab proyektil
    public Transform firePoint;         // Titik keluarnya proyektil
    public float projectileCooldown = 200f; // Waktu jeda antar tembakan
    private float lastProjectileTime;
    public Animator animator;
    public bool isPerformingUltimate = false;

    void Update()
    {
        // Jika bos siap menembak, lakukan serangan proyektil
        if (Time.time >= lastProjectileTime + projectileCooldown && !isPerformingUltimate)
        {
            animator.SetTrigger("attack_fireball");
            // FireProjectile();
            lastProjectileTime = Time.time; // Perbarui waktu tembakan terakhir
        }
    }
    void FireProjectile()
    {
        // Spawn proyektil di posisi firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Pastikan arah proyektil sesuai dengan orientasi bos
        BossAmmo projectileScript = projectile.GetComponent<BossAmmo>();

        if (transform.localScale.x < 0) // Menghadap kanan
        {
            projectileScript.speed = Mathf.Abs(projectileScript.speed); // Gerakan ke kanan
        }
        else // Menghadap kiri
        {
            projectileScript.speed = -Mathf.Abs(projectileScript.speed); // Gerakan ke kiri
        }
        if (transform.localScale.x < 0) // Menghadap kiri
        {
            projectile.transform.localScale = new Vector3(-1, 1, 1); // Flip sprite proyektil
        }
    }

    void ultimate(){
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Pastikan arah proyektil sesuai dengan orientasi bos
        BossAmmo projectileScript = projectile.GetComponent<BossAmmo>();
        if (transform.localScale.x < 0) // Menghadap kanan
        {
            projectileScript.speed = Mathf.Abs(projectileScript.speed); // Gerakan ke kanan
        }
        else // Menghadap kiri
        {
            projectileScript.speed = -Mathf.Abs(projectileScript.speed); // Gerakan ke kiri
        }
        if (transform.localScale.x < 0) // Menghadap kiri
        {
            projectile.transform.localScale = new Vector3(-1, 1, 1); // Flip sprite proyektil
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0){
        animator.SetTrigger("Hit"); // Animasi terkena serangan
        }else
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("die"); // Animasi kematian
        GetComponent<Collider2D>().enabled = false; // Matikan collider
        this.enabled = false; // Nonaktifkan script
        Destroy(gameObject, 1f); // Hapus boss setelah animasi
    }
}
