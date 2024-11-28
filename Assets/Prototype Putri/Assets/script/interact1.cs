using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact1 : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private bool hasInteracted = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasInteracted)
        {
            Debug.Log("terdeteksi");
            ui.SetActive(true);
            hasInteracted = true;
            //gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (hasInteracted)
        {
            ui.SetActive(false);
        }
    }
}
