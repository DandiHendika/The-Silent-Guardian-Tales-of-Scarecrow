using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyVision : MonoBehaviour
{
    public float detectionRange = 5f; // Jarak deteksi musuh
    public LayerMask playerLayer;    // Layer untuk mendeteksi pemain
    public GameObject gameOverScene;// Nama scene untuk Game Over

    public Vector2 offset = new Vector2(2f, 0f); // Offset untuk posisi depan musuh
    private SpriteRenderer spriteRenderer;      // Referensi ke SpriteRenderer
    public Rigidbody2D rb;
    public GameObject mnObj;

    void Start()
    {
        // Ambil SpriteRenderer untuk mendeteksi arah flip
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector3 visionPosition = GetVisionPosition();

        // Gunakan OverlapCircle untuk mendeteksi pemain di depan musuh
        Collider2D detectedPlayer = Physics2D.OverlapCircle(visionPosition, detectionRange, playerLayer);

        if (detectedPlayer != null)
        { 
            GameOver();
        }
    }

    Vector3 GetVisionPosition()
    {
        // Hitung posisi penglihatan berdasarkan arah flip
        float direction = spriteRenderer.flipX ? -1 : 1; // Flip ke kiri jika flipX
        return transform.position + new Vector3(offset.x * direction, offset.y, 0);
    }

    private void GameOver()
    {
        MainMenu mn = mnObj.GetComponent<MainMenu>();
        mn.isGameover = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        // Opsional: Tunggu sebentar sebelum kalah
        // yield return new WaitForSeconds(1f);

        // Ganti ke scene Game Over
        gameOverScene.gameObject.SetActive(true);
        // Time.timeScale = 1f;
        Time.timeScale = 0f;
    }

    // Debugging untuk menampilkan radius penglihatan
    void OnDrawGizmosSelected()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        Gizmos.color = Color.red;

        // Hitung posisi penglihatan untuk gizmo
        Vector3 visionPosition = GetVisionPosition();

        // Gambar lingkaran di posisi penglihatan
        Gizmos.DrawWireSphere(visionPosition, detectionRange);
    }
}

