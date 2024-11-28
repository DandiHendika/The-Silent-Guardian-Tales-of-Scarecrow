using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialText;
    public float displayDuration ;
    private string[] ShowMassage = {
        "Selamat datang di permainan! \nTekan panah kanan untuk bergerak.",
        "Tekan panah atas untuk lompat!",
        "Hati-hati, musuh ada di depan!",
        "Selamat bermain dan semoga sukses!"
    };
    private int currentMessageIndex = 0;

    void Start()
    {
        ShowMessage();
    }

    void ShowMessage()
    {
        if (currentMessageIndex < ShowMassage.Length)
        {
            tutorialText.GetComponent<TextMeshProUGUI>().text = ShowMassage[currentMessageIndex];
            tutorialText.SetActive(true);
            Invoke("NextMessage", displayDuration); 
        }
        else
        {
            HideTutorial();
        }
    }

    void NextMessage()
    {
        currentMessageIndex++;
        ShowMessage();
    }

    void HideTutorial()
    {
        tutorialText.SetActive(false);
    }

}
