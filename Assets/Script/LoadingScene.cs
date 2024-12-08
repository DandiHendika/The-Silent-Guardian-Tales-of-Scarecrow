using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public GameObject loading;
    public VideoPlayer videoPlayer; 

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false; 

        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        
        loading.SetActive(true);
        videoPlayer.Play();
        if (videoPlayer.isPlaying)
        {
            Debug.Log("Video sedang diputar");
        }
        else
        {
            Debug.LogError("Video tidak diputar");
        }

        while (videoPlayer.isPlaying)
        {
            yield return null; 
        }

        if (sceneId > PlayerPrefs.GetInt("levelAt", 2))
        {
            PlayerPrefs.SetInt("levelAt", sceneId);
            PlayerPrefs.Save();
        }

        operation.allowSceneActivation = true;
    }
}
