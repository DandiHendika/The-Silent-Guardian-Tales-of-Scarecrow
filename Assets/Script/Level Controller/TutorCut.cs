using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorCut : MonoBehaviour
{
    public Image cutsceneImage; 
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public float cutsceneDuration = 3f; 
    public float dialoguesDuration = 1f; 
    public float Duration = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(ShowCutscene());
    }

    private IEnumerator ShowCutscene()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        cutsceneImage.gameObject.SetActive(true);

    
        for (float t = 0; t < 1; t += Time.deltaTime / 1f)
        {
            cutsceneImage.color = new Color(1, 1, 1, t);
            yield return null;
        }

        yield return new WaitForSeconds(cutsceneDuration);

    
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
        dialog1.gameObject.SetActive(true);
       
        yield return new WaitForSeconds(dialoguesDuration);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(dialoguesDuration);
        dialog2.gameObject.SetActive(false);
        dialog3.gameObject.SetActive(true);

        yield return new WaitForSeconds(dialoguesDuration);
        dialog3.gameObject.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
