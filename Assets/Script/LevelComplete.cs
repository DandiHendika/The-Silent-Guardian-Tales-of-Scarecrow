using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int currentLevelIndex; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            LevelManager.UnlockNextLevel(currentLevelIndex); 
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }
}
