using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndingVideoSequence : MonoBehaviour
{
    [Header("Main Video Settings")]
    public VideoPlayer mainVideoPlayer;    // VideoPlayer untuk video utama
    public GameObject mainVideoCanvas;     // Canvas untuk video utama

    [Header("Credits Video Settings")]
    public VideoPlayer creditsVideoPlayer; // VideoPlayer untuk credits
    public GameObject creditsVideoCanvas;  // Canvas untuk credits

    [Header("Settings")]
    public float creditsDuration = 5f;     // Tambahan durasi untuk credits (opsional)
    public int mainMenuSceneIndex = 0;     // Index scene untuk Main Menu (atur di Build Settings)

    private bool sequenceStarted = false;  // Untuk memastikan urutan hanya dijalankan sekali

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
        // Memutar video utama
        yield return PlayVideo(mainVideoPlayer, mainVideoCanvas);

        // Memutar video credits
        yield return PlayVideo(creditsVideoPlayer, creditsVideoCanvas);

        // Tunggu tambahan durasi credits (jika dibutuhkan)

        // Pindah ke main menu
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    private IEnumerator PlayVideo(VideoPlayer videoPlayer, GameObject videoCanvas)
    {
        // Persiapkan video
        videoPlayer.Prepare();

        // Tunggu hingga video siap
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Tampilkan canvas dan mulai video
        videoCanvas.SetActive(true);
        videoPlayer.Play();

        // Tunggu hingga video selesai
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Sembunyikan canvas setelah selesai
        videoCanvas.SetActive(false);
    }
}
