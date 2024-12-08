using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreenManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    void Start()
    {
        
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(1); 
    }
}
