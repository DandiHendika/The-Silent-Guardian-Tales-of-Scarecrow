using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Image cutsceneImage; // Referensi ke UI Image
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject player;
    public GameObject playerImg;
    public float cutsceneDuration = 3f; // Durasi cutscene dalam detik
    public float dialoguesDuration = 1f; // Durasi transisi antar layar dalam
    public float Duration = 5f;

    private void Start()
    {
        StartCoroutine(ShowCutscene());
    }

    private IEnumerator ShowCutscene()
    {
        cutsceneImage.gameObject.SetActive(true);

    // Fade in
        for (float t = 0; t < 1; t += Time.deltaTime / 1f)
        {
            cutsceneImage.color = new Color(1, 1, 1, t);
            yield return null;
        }

        yield return new WaitForSeconds(cutsceneDuration);

    // Fade out
        for (float t = 1; t > 0; t -= Time.deltaTime / 1f)
        {
            cutsceneImage.color = new Color(1, 1, 1, t);
            yield return null;
        }

        cutsceneImage.gameObject.SetActive(false);
        StartCoroutine(ShowDialogues());
    }

    private IEnumerator ShowDialogues()
    {
        playerImg.gameObject.SetActive(true);
        dialog1.gameObject.SetActive(true);
       
        yield return new WaitForSeconds(dialoguesDuration);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(dialoguesDuration);
        playerImg.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        player.gameObject.SetActive(true);

    }
}
