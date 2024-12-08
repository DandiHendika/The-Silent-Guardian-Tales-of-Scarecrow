using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PuzzleController : MonoBehaviour
{
    public Button[] pzButtonsLock;
    public Button[] pzButtonsUnlock;

    
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 0);

        for (int i = 0; i < pzButtonsLock.Length; i++)
        {
            if (i + 1 > levelAt)
                pzButtonsLock[i].gameObject.SetActive(false);
                pzButtonsUnlock[i].gameObject.SetActive(true);
        }
    }
}
