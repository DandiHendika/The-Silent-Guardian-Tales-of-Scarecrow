using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovementUp : MonoBehaviour
{
    public float speed = 2f;                // Kecepatan gerakan
    public float moveDistance = 4f;        // Jarak maksimum dari posisi awal

    private Vector3 startPosition;         // Posisi awal objek
    private bool movingUp = true;          // Arah gerakan (true = ke atas, false = ke bawah)


    void Start()
    {
        // Simpan posisi awal
        startPosition = transform.position;
    }

    void Update()
    {
        // Tentukan arah gerakan
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Cek apakah sudah mencapai batas atas
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false; // Ubah arah ke bawah
            }
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

            // Cek apakah sudah mencapai posisi awal
            if (transform.position.y <= startPosition.y)
            {
                movingUp = true; // Ubah arah ke atas
            }
        }
    }
}

