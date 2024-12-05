using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuizObject : MonoBehaviour
{
    public GameObject teksbenar;
    public GameObject tekssalah;
    public string question; // Pertanyaan
    public string correctAnswer; // Jawaban benar
    public TMP_Text questionText; // Komponen Text untuk menampilkan pertanyaan
    public TMP_InputField answerInput; // InputField untuk jawaban
    public GameObject quizPanel; // Panel kuiz spesifik untuk objek ini
    public static int starCount = 0; // Jumlah bintang yang didapatkan player
    private Animator anim;
    private bool playerInRange = false;
    private float interactionRange = 7f;
    [SerializeField] private GameObject teks;
    [SerializeField] private GameObject teksDialog;
    [SerializeField] private Transform player;

    void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update(){
        if (Vector3.Distance(player.position, transform.position) <= interactionRange)
        {
            playerInRange = true;
        }else{
            playerInRange = false;
        }

        if(playerInRange && quizPanel != null){
            teksDialog.SetActive(true);
            teks.SetActive(true);
        }else{
            teksDialog.SetActive(false);
            teks.SetActive(false);
        }
    }

    public void ShowQuiz()
    {
        questionText.text = question; // Tampilkan pertanyaan
        answerInput.text = ""; // Kosongkan input
    }

    public void ActivateQuizPanel()
    {
        if (quizPanel != null)
        {
            quizPanel.SetActive(true); // Tampilkan panel kuis untuk objek ini
            ShowQuiz(); // Tampilkan pertanyaan kuis
        }
    }

    public void SubmitAnswer()
    {
        if (answerInput.text.ToLower() == correctAnswer.ToLower())
        {
            tekssalah.SetActive(false);
            starCount++; // Tambah bintang jika jawaban benar
            teksbenar.SetActive(true); // Tampilkan teks jawaban benar
            Debug.Log("Jawaban benar! Bintang: " + starCount); // Sembunyikan panel kuis
            anim.SetTrigger("die"); // Aktifkan animasi koreksi
            teks.SetActive(false);
            teksDialog.SetActive(false);
            this.enabled = false;
        }
        else
        {
            tekssalah.SetActive(true); // Tampilkan teks jawaban salah
            Debug.Log("Jawaban salah!");
        }
    }

    public void destroyObj(){
        Destroy(gameObject);
    }

    public void hideObj(){
        quizPanel.SetActive(false);
    }
}
