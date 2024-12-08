using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuizObject : MonoBehaviour
{
    public GameObject teksbenar;
    public GameObject tekssalah;
    public string question; 
    public string correctAnswer; 
    public TMP_Text questionText; 
    public TMP_InputField answerInput; 
    public GameObject quizPanel; 
    public static int starCount = 0; 
    private Animator anim;
    private bool playerInRange = false;
    private float interactionRange = 7f;
    [SerializeField] private GameObject teks;
    [SerializeField] private GameObject teksDialog;
    [SerializeField] private Transform player;

    void Start(){
        anim = GetComponent<Animator>();
        starCount = 0;
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

        if(quizPanel == null){
            player.gameObject.SetActive(true);
        }
    }

    public void ShowQuiz()
    {
        questionText.text = question; 
        answerInput.text = ""; 
    }

    public void ActivateQuizPanel()
    {
        if (quizPanel != null)
        {
            player.gameObject.SetActive(false);
            quizPanel.SetActive(true); 
            ShowQuiz(); 
        }
    }

    public void SubmitAnswer()
    {
        if (answerInput.text.ToLower() == correctAnswer.ToLower())
        {
            player.gameObject.SetActive(true);
            tekssalah.SetActive(false);
            starCount++; 
            teksbenar.SetActive(true); 
            Debug.Log("Jawaban benar! Bintang: " + starCount); 
            anim.SetTrigger("die"); 
            teks.SetActive(false);
            teksDialog.SetActive(false);
            this.enabled = false;
        }
        else
        {
            tekssalah.SetActive(true); 
            Debug.Log("Jawaban salah!");
        }
    }

    public void destroyObj(){
        Destroy(gameObject);
    }

    public void hideObj(){
        quizPanel.SetActive(false);
    }

    public void Aktifkan(){
        player.gameObject.SetActive(true);
    }
}
