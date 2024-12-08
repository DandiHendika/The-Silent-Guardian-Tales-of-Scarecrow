using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private QuizObject currentQuizObject; 
    private GameObject player;

    void Start(){
        player = GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentQuizObject != null)
        {
            currentQuizObject.ActivateQuizPanel(); 
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
