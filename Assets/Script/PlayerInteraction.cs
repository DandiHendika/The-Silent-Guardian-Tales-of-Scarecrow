using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject quizPanel; // Panel kuiz di UI
    private QuizObject currentQuizObject; // Objek kuiz yang sedang diinteraksi

    void Update()
    {
        // Deteksi tombol E untuk berinteraksi
        if (Input.GetKeyDown(KeyCode.E) && currentQuizObject != null)
        {
            quizPanel.SetActive(true); // Tampilkan panel kuiz
            currentQuizObject.ShowQuiz(); // Panggil metode untuk menampilkan kuiz
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("QuizObject"))
        {
            currentQuizObject = collision.GetComponent<QuizObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("QuizObject"))
        {
            currentQuizObject = null;
        }
    }
}
