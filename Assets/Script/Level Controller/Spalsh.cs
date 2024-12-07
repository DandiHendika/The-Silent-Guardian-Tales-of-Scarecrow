using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreenManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Drag VideoPlayer di Inspector   // Isi dengan nama scene berikutnya di Inspector

    void Start()
    {
        // Event dipanggil setelah video selesai
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(1); // Pindah ke scene berikutnya
    }
}
