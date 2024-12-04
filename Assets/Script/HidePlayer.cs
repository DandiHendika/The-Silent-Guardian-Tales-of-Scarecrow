using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;              // Referensi ke GameObject pemain
    [SerializeField] private Transform hidingSpot;           // Lokasi objek interaksi (tempat bersembunyi)
    public float interactionRange = 2f;                     // Jarak interaksi maksimum
    private bool isHidden = false;                          // Status apakah player sedang tersembunyi

    // Variabel untuk pengaturan Gizmo
    public Color gizmoColor = new Color(0, 1, 0, 0.5f);     // Warna Gizmo (default hijau transparan)
    public bool drawSolidGizmo = false;                     // Apakah Gizmo digambar solid atau wireframe

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, hidingSpot.position);

        if (distance <= interactionRange)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                ToggleHide();
            }
        }
    }

    void ToggleHide()
    {
        if (isHidden)
        {
            player.SetActive(true);
            isHidden = false;
        }
        else
        {
            player.SetActive(false);
            isHidden = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (hidingSpot != null)
        {
            Gizmos.color = gizmoColor; // Set warna Gizmo
            if (drawSolidGizmo)
            {
                // Gambar lingkaran solid
                Gizmos.DrawSphere(hidingSpot.position, interactionRange);
            }
            else
            {
                // Gambar lingkaran wireframe
                Gizmos.DrawWireSphere(hidingSpot.position, interactionRange);
            }
        }
    }
}
