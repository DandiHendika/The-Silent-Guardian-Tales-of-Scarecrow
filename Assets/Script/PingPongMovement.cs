using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float speed = 2f;                // Kecepatan gerakan
    public float moveDistance = 4f;        // Jarak maksimum dari posisi awal

    private Vector3 startPosition;         // Posisi awal objek
    private bool movingRight = false;      // Arah gerakan (false = ke kiri, true = ke kanan)
    SpriteRenderer sprite;

    void Start()
    {
        // Simpan posisi awal
        startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Tentukan arah gerakan
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            // Cek apakah sudah mencapai batas kanan
            if (transform.position.x >= startPosition.x)
            {
                movingRight = false; // Ubah arah ke kiri
                sprite.flipX = false; // Ubah arah gambar
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            // Cek apakah sudah kembali ke posisi awal
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Ubah arah ke kanan
                sprite.flipX = true; // Ubah arah gambar
            }
        }
    }
}
