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


        // Tunggu hingga video selesai diputar
        while (!videoPlayer.isPrepared)
        {
            yield return null; // Tunggu hingga video siap
        }

        while (videoPlayer.isPlaying)
        {
            yield return null; // Tunggu hingga video selesai
        }

        // Aktifkan scene berikutnya setelah video selesai
        operation.allowSceneActivation = true;
    }
}
