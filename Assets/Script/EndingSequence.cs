using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndingVideoSequence : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // VideoPlayer untuk memutar video ending
    public GameObject videoCanvas;        // Canvas atau panel untuk video ending
    public GameObject creditsPanel;       // Panel untuk credits
    public float creditsDuration = 10f;   // Durasi untuk panel credits
    public int mainMenuSceneIndex = 0;    // Index scene main menu (ubah sesuai build settings)

    private bool sequenceStarted = false;

    public void StartEndingSequence()
    {
        if (!sequenceStarted)
        {
            sequenceStarted = true;
            StartCoroutine(PlayEndingVideoSequence());
        }
    }

    private IEnumerator PlayEndingVideoSequence()
    {
        videoPlayer.Prepare();

        // Tunggu hingga video selesai dipersiapkan
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Tampilkan video canvas
        videoCanvas.SetActive(true);
        videoPlayer.Play();

        // Tunggu hingga video selesai diputar
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Sembunyikan video canvas setelah selesai
        videoCanvas.SetActive(false);

        // Tampilkan panel credits
        creditsPanel.SetActive(true);
        yield return new WaitForSeconds(creditsDuration);

        // Kembali ke main menu
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
