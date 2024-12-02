using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Animator animator; // Referensi Animator
    public float destroyDelay = 1f; // Waktu sebelum telur dihancurkan setelah pecah

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah telur menyentuh Player
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerBreak(); // Pecahkan telur
            // Tambahkan logika seperti mengurangi HP player jika perlu
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            TriggerBreak(); // Pecahkan telur
        }
    }

    void TriggerBreak()
    {
        // Aktifkan animasi pecah
        animator.SetTrigger("pecah");

        // Hancurkan objek setelah animasi selesai
        Destroy(gameObject, destroyDelay);
    }
}
