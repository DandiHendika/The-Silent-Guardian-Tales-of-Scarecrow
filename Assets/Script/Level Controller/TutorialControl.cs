using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    private bool playerInRange = false;
    private float interactionRange = 4f;
    [SerializeField] private GameObject teksDialog;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionRange)
        {
            playerInRange = true;
        }else{
            playerInRange = false;
        }

        if(playerInRange){
            teksDialog.SetActive(true);
        }else{
            teksDialog.SetActive(false);
        }
    }
}
