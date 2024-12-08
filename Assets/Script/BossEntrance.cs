using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    public GameObject boss;                 
    public GameObject cage;                 
    public GameObject cage2;
    public GameObject bossTransformSprite;  
    public GameObject cameraBoss;           
    public GameObject cameraPlayer;         
    public GameObject[] dialogPanels;       
    public float dialogDuration = 3f;       
    private bool isTriggered = false;       
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
        
        dialogPanels[0].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[0].SetActive(false);

        
        dialogPanels[1].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[1].SetActive(false);

        
        bossTransformSprite.SetActive(true);
        yield return new WaitForSeconds(0.7f); 
        bossTransformSprite.SetActive(false);

        
        dialogPanels[2].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[2].SetActive(false);

        
        dialogPanels[3].SetActive(true);
        yield return new WaitForSeconds(dialogDuration);
        dialogPanels[3].SetActive(false);

        EndDialogSequence();
    }

    private void EndDialogSequence()
    {
        
        boss.SetActive(true); 
    }
}
