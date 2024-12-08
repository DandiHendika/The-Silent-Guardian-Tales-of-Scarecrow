using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; 
    public Sprite spriteDefault; 
    public Sprite spriteDisabled; 
    public Sprite spriteDefault2; 
    public Sprite spriteDisabled2; 
    public Sprite spriteDefault3; 
    public Sprite spriteDisabled3; 

    void Start()
    {
        
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);     
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true; 
                levelButtons[0].GetComponent<Image>().sprite = spriteDefault;
                levelButtons[1].GetComponent<Image>().sprite = spriteDefault2;
                levelButtons[2].GetComponent<Image>().sprite = spriteDefault3;
            }
            else
            {
                levelButtons[i].interactable = false; 
                levelButtons[0].GetComponent<Image>().sprite = spriteDisabled;
                levelButtons[1].GetComponent<Image>().sprite = spriteDisabled2;
                levelButtons[2].GetComponent<Image>().sprite = spriteDisabled3;
            }
        }
    }

    
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    
    public static void UnlockNextLevel(int levelIndex)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelIndex >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndex + 1);
            PlayerPrefs.Save();
        }
    }
}
