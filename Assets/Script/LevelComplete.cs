using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int currentLevelIndex; // Indeks level ini (sesuai urutan di Build Settings)

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Pastikan hanya pemain yang bisa memicu
        {
            LevelManager.UnlockNextLevel(currentLevelIndex);

            // Contoh: Kembali ke Main Menu
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }
}
