using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject SelectMenu;
    public GameObject Menu;
    public GameObject Setting;
    public bool isPaused = false;
    public bool isGameover = false;

    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void Continue(){
        Menu.SetActive(false);
        Time.timeScale = 1f;   
        isPaused = false;
    }

    public void Pause(){
        Menu.SetActive(true);        
        Time.timeScale = 0f;               
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void SettingTab()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;               
        isPaused = true;
    }

    public void SelectLevel()
    {
        SelectMenu.SetActive(true);
    }

    public void SelecetTutorial(){
        SceneManager.LoadScene(1);
    }

    public void SelecetLevelOne(){
        SceneManager.LoadScene(2);
    }

    public void SelecetLevelTwo(){
        SceneManager.LoadScene(3);
    }

    public void Restart(){
        isGameover = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetPrefs(){
        PlayerPrefs.DeleteKey("levelAt");
        // PlayerPrefs.Save();
        Debug.Log("PlayerPrefs telah direset.");
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        Application.Quit();
    }

    void Start(){
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(isGameover)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }
}
