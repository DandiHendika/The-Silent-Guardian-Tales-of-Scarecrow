using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Titik awal
    public Transform pointB; // Titik akhir
    public float speed = 2f; // Kecepatan platform

    private Vector3 targetPosition; // Posisi tujuan

    void Start()
    {
        // Mulai dengan menuju titik A
        targetPosition = pointA.position;
    }

    void Update()
    {
        // Gerakkan platform menuju target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Cek jika platform sudah mencapai target
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Ubah target ke titik lainnya
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform); // Tempelkan player ke platform
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null); // Lepaskan player dari platform
        }
    }

}
