using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Referensi untuk tombol level di UI

    void Start()
    {
        // Dapatkan level yang sudah terbuka dari PlayerPrefs
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Default level 1 terbuka

        // Perbarui tombol level berdasarkan level yang terbuka
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true; // Aktifkan tombol
            }
            else
            {
                levelButtons[i].interactable = false; // Nonaktifkan tombol
            }
        }
    }

    // Fungsi untuk memulai level
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // Fungsi untuk membuka level berikutnya (panggil saat level selesai)
    public static void UnlockNextLevel(int levelIndex)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelIndex >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndex + 1);
            PlayerPrefs.Save();
        }
    }
}
