using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float followSpeed = 2f; // Kecepatan mengikuti
    public GameObject eggPrefab; // Prefab telur
    public Transform eggSpawnPoint; // Posisi spawn telur
    public float dropInterval = 2f; // Interval menjatuhkan telur

    private Transform player; // Referensi posisi pemain
    private bool isPlayerInRange = false;
    private bool canDropEgg = true;

    void Update()
    {
        if (isPlayerInRange && player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Gerakkan enemy ke arah pemain
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + 5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Cek apakah berada di atas pemain
        if (Mathf.Abs(transform.position.x - player.position.x) < 0.5f)
        {
            DropEgg();
        }
    }

    void DropEgg()
    {
        if (canDropEgg)
        {
            canDropEgg = false;
            Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
            StartCoroutine(ResetDropEgg());
        }
    }

    IEnumerator ResetDropEgg()
    {
        yield return new WaitForSeconds(dropInterval);
        canDropEgg = true;
    }

    // Event ketika pemain masuk ke dalam area deteksi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = collision.transform;
        }
    }

    // Event ketika pemain keluar dari area deteksi
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;
        }
    }

    // Visualisasi wilayah deteksi dengan Gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f); // Radius deteksi untuk visualisasi
    }
}
