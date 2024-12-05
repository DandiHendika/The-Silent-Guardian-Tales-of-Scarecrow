using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusicSource;
    [SerializeField] private AudioClip[] sceneMusics; // Daftar musik untuk setiap scene
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        PlayBackgroundMusic(currentSceneIndex);
    }

    public void PlayBackgroundMusic(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < sceneMusics.Length)
        {
            bgMusicSource.clip = sceneMusics[sceneIndex];
            bgMusicSource.Play();
        }
    }

    public void ChangeToBossMusic(AudioClip bossMusic)
    {
        bgMusicSource.Stop();
        bgMusicSource.clip = bossMusic;
        bgMusicSource.Play();
    }
}

