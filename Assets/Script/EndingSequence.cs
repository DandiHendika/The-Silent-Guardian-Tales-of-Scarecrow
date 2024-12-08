using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndingVideoSequence : MonoBehaviour
{
    [Header("Main Video Settings")]
    public VideoPlayer mainVideoPlayer;    
    public GameObject mainVideoCanvas;     

    [Header("Credits Video Settings")]
    public VideoPlayer creditsVideoPlayer; 
    public GameObject creditsVideoCanvas;  

    [Header("Settings")]
    public float creditsDuration = 5f;     
    public int mainMenuSceneIndex = 0;     

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
        
        yield return PlayVideo(mainVideoPlayer, mainVideoCanvas);
        
        yield return PlayVideo(creditsVideoPlayer, creditsVideoCanvas);

        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    private IEnumerator PlayVideo(VideoPlayer videoPlayer, GameObject videoCanvas)
    {
        
        videoPlayer.Prepare();
        
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        
        videoCanvas.SetActive(true);
        videoPlayer.Play();
        
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        
        videoCanvas.SetActive(false);
    }
}
