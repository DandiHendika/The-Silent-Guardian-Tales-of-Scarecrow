using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizObject : MonoBehaviour
{
    public string question; // Pertanyaan
    public string correctAnswer; // Jawaban benar
    public TMP_Text questionText; // Komponen Text untuk menampilkan pertanyaan
    public TMP_InputField answerInput; // InputField untuk jawaban
    public GameObject quizPanel; // Panel kuiz
    public static int starCount = 0; // Jumlah bintang yang didapatkan player
    private bool playerInRange = false;
    private float interactionRange = 6f;
    [SerializeField] private GameObject teks;
    [SerializeField] private Transform player;

    private void Update(){
        if (Vector3.Distance(player.position, transform.position) <= interactionRange)
        {
            playerInRange = true;
        }

        if(playerInRange){
            teks.SetActive(true);
        }
    }
    public void ShowQuiz()
    {
        questionText.text = question; // Tampilkan pertanyaan
        answerInput.text = ""; // Kosongkan input
    }

    public void SubmitAnswer()
    {
        if (answerInput.text.ToLower() == correctAnswer.ToLower())
        {
            starCount++; // Tambah bintang jika jawaban benar
            Debug.Log("Jawaban benar! Bintang: " + starCount);
        }
        else
        {
            Debug.Log("Jawaban salah!");
        }

        quizPanel.SetActive(false); // Sembunyikan panel kuiz
        Destroy(gameObject); // Hancurkan objek kuiz agar tidak bisa diinteraksi lagi
    }
}
