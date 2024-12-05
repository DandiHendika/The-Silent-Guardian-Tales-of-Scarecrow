using UnityEngine;
using System.Collections;

public class Papan : MonoBehaviour
{
    [SerializeField] private float delayBeforeDisappear = 3f; // Waktu sebelum platform menghilang
    [SerializeField] private float appearDelay = 2f; // Waktu sebelum platform muncul kembali

    private Vector3 initialPosition;
    private bool isActive = true;
    private Collider2D platformCollider;
    private SpriteRenderer platformRenderer;

    private void Start()
    {
        initialPosition = transform.position;
        platformCollider = GetComponent<Collider2D>(); // Mendapatkan komponen Collider2D
        platformRenderer = GetComponent<SpriteRenderer>(); // Mendapatkan komponen SpriteRenderer
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            StartCoroutine(DisappearAfterDelay());
            ResetPlatform();
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);
        // Nonaktifkan collider dan ubah objek menjadi transparan
        platformCollider.enabled = false;
        platformRenderer.color = new Color(platformRenderer.color.r, platformRenderer.color.g, platformRenderer.color.b, 0f); // Membuat objek transparan

        // Tunggu beberapa detik sebelum memulihkan
        yield return new WaitForSeconds(appearDelay);

        // Pulihkan collider dan objek menjadi tidak transparan
        platformCollider.enabled = true;
        platformRenderer.color = new Color(platformRenderer.color.r, platformRenderer.color.g, platformRenderer.color.b, 1f); // Kembalikan objek menjadi terlihat
    }

    public void ResetPlatform()
    {
        // Reset posisi objek jika diperlukan
        transform.position = initialPosition;
        isActive = true;
    }

    public void DisablePlatform()
    {
        isActive = false;
    }
}
