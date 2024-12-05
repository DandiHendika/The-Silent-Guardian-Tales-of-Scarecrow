using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string playerTag = "Player";   // Tag untuk pemain
    public GameObject winMessage;        // UI pesan kemenangan
    public float loadDelay = 3f;         // Waktu sebelum pindah ke Scene 0

    private bool isFinished = false;     // Cegah trigger berulang
    public TMP_Text starText;

    void Start()
    {
        // Pastikan pesan kemenangan tidak langsung muncul
        if (winMessage != null)
        {
            winMessage.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah objek yang masuk adalah pemain
        if (!isFinished && collision.CompareTag(playerTag))
        {
            isFinished = true; // Tandai bahwa finish line sudah tercapai

            // Tampilkan pesan kemenangan
            if (winMessage != null)
            {
                starText.text = "Bintang: " + QuizObject.starCount + "/3"; // Tampilkan jumlah bintang
                winMessage.SetActive(true);
            }
            // Pause game
            // Time.timeScale = 0f;
        }
    }
}

