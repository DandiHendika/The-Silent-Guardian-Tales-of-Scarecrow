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
    [SerializeField] private GameObject benar;
    [SerializeField] private GameObject salah;
    [SerializeField] private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update(){
        if (Vector3.Distance(player.position, transform.position) <= interactionRange)
        {
            playerInRange = true;
        }

        if(playerInRange){
            teks.SetActive(true);
        }else{
            teks.SetActive(false);
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
            salah.gameObject.SetActive(false);
            benar.gameObject.SetActive(true);
            quizPanel.SetActive(false); // Sembunyikan panel kuiz
            anim.SetTrigger("die");
            // Hancurkan objek kuiz agar tidak bisa diinteraksi lagi
        }
        else
        {
            Debug.Log("Jawaban salah!");
            benar.gameObject.SetActive(false);
            salah.gameObject.SetActive(true);
        }
    }

    public void DestroyObj(){
        Destroy(gameObject);
    }
}
