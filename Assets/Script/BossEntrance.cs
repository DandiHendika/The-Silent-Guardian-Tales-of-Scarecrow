using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    public GameObject boss;                 // Objek bos
    public GameObject cage;                 // Objek kandang
    public GameObject cage2;
    public GameObject bossTransformSprite;  // Sprite transformasi bos
    public GameObject cameraBoss;           // Kamera fokus ke bos
    public GameObject cameraPlayer;         // Kamera fokus ke pemain
    public GameObject[] dialogPanels;       // Panel dialog (4 panel)
    public float dialogDuration = 3f;       // Durasi setiap dialog dalam detik
    private bool isTriggered = false;       // Apakah pemain telah memicu bos
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip bossMusic;

    private void Update(){
        if (boss.IsDestroyed()) {
            audioManager.StopMusicBoss();
    }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            cameraPlayer.SetActive(false);
            cameraBoss.SetActive(true);
            StartCoroutine(ShowDialogSequence());
            audioManager.ChangeToBossMusic(bossMusic);
        }
    }

    private IEnumerator ShowDialogSequence()
    {
        cage.SetActive(true);
        cage2.SetActive(true);
        // Tampilkan dialog 1
        dialogPanels[0].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[0].SetActive(false);

        // Tampilkan dialog 2
        dialogPanels[1].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[1].SetActive(false);

        // Tampilkan animasi transformasi bos
        bossTransformSprite.SetActive(true);
        yield return new WaitForSeconds(0.7f); // Durasi animasi transformasi
        bossTransformSprite.SetActive(false);

        // Tampilkan dialog 3
        dialogPanels[2].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[2].SetActive(false);

        // Tampilkan dialog 4
        dialogPanels[3].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[3].SetActive(false);

        EndDialogSequence();
    }

    private void EndDialogSequence()
    {
        // Setelah semua dialog selesai
        boss.SetActive(true); // Aktifkan bos // Aktifkan kandang
    }
}
