using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public int NextLevels;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        NextLevels = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 5)
            {
                Debug.Log("You Completed ALL Levels");   
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad);   
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("You Completed ALL Levels");
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);       
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", NextLevels);
            }
         }
    }
}
