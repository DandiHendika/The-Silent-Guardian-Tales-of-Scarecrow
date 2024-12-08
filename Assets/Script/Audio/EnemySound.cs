using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource flySound; 
    [SerializeField] private AudioSource ratSound; 

    void Start()
    {
        if (flySound != null) flySound.Play(); 
        if (ratSound != null) ratSound.Play(); 
    }
}
