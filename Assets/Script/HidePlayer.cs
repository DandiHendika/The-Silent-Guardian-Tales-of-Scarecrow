using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;              // Referensi ke GameObject pemain
    [SerializeField] private Transform hidingSpot;           // Lokasi objek interaksi (tempat bersembunyi)
    [SerializeField] private GameObject text;
    public float interactionRange = 2f;    // Jarak interaksi maksimum
    private bool isHidden = false;         // Status apakah player sedang tersembunyi

    void Update()
    {
        // Cek apakah pemain berada dalam jangkauan interaksi
        float distance = Vector3.Distance(player.transform.position, hidingSpot.position);

        if (distance <= interactionRange)
        {
            text.SetActive(true);
            // Tampilkan teks atau indikator interaksi (opsional)
            Debug.Log("Press 'H' to hide/unhide");

            // Deteksi tombol H untuk bersembunyi/keluar
            if (Input.GetKeyDown(KeyCode.H))
            {
                ToggleHide();
            }
        }else{
            text.SetActive(false);
        }
    }

    void ToggleHide()
    {
        if (isHidden)
        {
            // Keluarkan pemain dari persembunyian
            player.SetActive(true);
            isHidden = false;
        }
        else
        {
            // Sembunyikan pemain
            player.SetActive(false);
            isHidden = true;
        }
    }
}

