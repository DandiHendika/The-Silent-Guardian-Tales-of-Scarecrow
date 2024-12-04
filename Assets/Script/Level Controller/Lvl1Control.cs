using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Control : MonoBehaviour
{
    private bool playerInRange = false;
    private float interactionRange = 3f;
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

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.SetActive(false);
        }
    }
}
