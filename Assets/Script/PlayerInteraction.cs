using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private QuizObject currentQuizObject; // Objek kuiz yang sedang diinteraksi
    private GameObject player;

    void Start(){
        player = GetComponent<GameObject>();
    }

    void Update()
    {
        // Deteksi tombol E untuk berinteraksi
        if (Input.GetKeyDown(KeyCode.E) && currentQuizObject != null)
        {
            currentQuizObject.ActivateQuizPanel(); // Aktifkan panel kuis dari QuizObject
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
