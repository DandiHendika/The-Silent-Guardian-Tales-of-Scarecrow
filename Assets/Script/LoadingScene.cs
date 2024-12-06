using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    public GameObject loading;
    public VideoPlayer videoPlayer; // Tambahkan reference untuk VideoPlayer

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        // Mulai loading scene secara async
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false; // Jangan pindah ke scene sampai video selesai

        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        // Aktifkan loading screen dan mulai video
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
            yield return null; // Tunggu hingga video selesai
        }

        if (sceneId > PlayerPrefs.GetInt("levelAt", 1))
        {
            PlayerPrefs.SetInt("levelAt", sceneId);
            PlayerPrefs.Save();
        }

        // Aktifkan scene berikutnya setelah video selesai
        operation.allowSceneActivation = true;
    }
}
