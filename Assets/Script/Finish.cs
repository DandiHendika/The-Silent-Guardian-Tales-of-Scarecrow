using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string playerTag = "Player";   
    public GameObject winMessage;        
    public float loadDelay = 3f;         

    private bool isFinished = false;     

    void Start()
    {
        
        if (winMessage != null)
        {
            winMessage.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!isFinished && collision.CompareTag(playerTag))
        {
            isFinished = true; 
           
            if (winMessage != null)
            {
                SoundManager.Instance.PlaySound2D("Win");
                winMessage.SetActive(true);
            }            
        }
    }
}

