using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSequence : MonoBehaviour
{
    public GameObject endingPanel;       // Panel untuk ending
    public GameObject creditsPanel;     // Panel untuk credits
    public float endingDuration = 5f;   // Durasi untuk panel ending
    public float creditsDuration = 10f; // Durasi untuk panel credits
    public int mainMenuSceneIndex = 0;  // Index scene main menu (ubah sesuai build settings)

    private bool sequenceStarted = false;

    public void StartEndingSequence()
    {
        if (!sequenceStarted)
        {
            sequenceStarted = true;
            StartCoroutine(PlayEndingSequence());
        }
    }

    private IEnumerator PlayEndingSequence()
    {
        // Tampilkan panel ending
        endingPanel.SetActive(true);
        yield return new WaitForSeconds(endingDuration);
        endingPanel.SetActive(false);

        // Tampilkan panel credits
        creditsPanel.SetActive(true);
        yield return new WaitForSeconds(creditsDuration);
        creditsPanel.SetActive(false);

        // Kembali ke main menu
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
