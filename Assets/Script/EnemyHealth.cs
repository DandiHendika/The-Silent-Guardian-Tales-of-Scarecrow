using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;       // Maksimum HP
    private int currentHealth;      // HP saat ini
    private Animator animator;       // Animator untuk animasi
    public float destroyDelay = 1f; // Waktu jeda sebelum menghilang setelah animasi mati

    void Start()
    {
        // Atur HP ke nilai maksimum
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Fungsi untuk menerima damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Kurangi HP

        // Cek jika HP habis
        if (currentHealth <= 0)
        {
            Die(); // Trigger kematian
        }
    }

    private void Die()
    {
        // Trigger animasi mati
        animator.SetTrigger("Die");

        // Nonaktifkan collider agar tidak bisa disentuh lagi
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Hancurkan objek setelah animasi selesai
        Destroy(gameObject, destroyDelay);
    }
}

