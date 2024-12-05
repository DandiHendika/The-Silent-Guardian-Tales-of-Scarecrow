using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource flySound; // Untuk musuh terbang
    [SerializeField] private AudioSource ratSound; // Untuk musuh tikus

    void Start()
    {
        if (flySound != null) flySound.Play(); // Memutar sound musuh terbang
        if (ratSound != null) ratSound.Play(); // Memutar sound musuh tikus
    }
}
