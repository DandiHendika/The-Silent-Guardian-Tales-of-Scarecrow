using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPosisition : MonoBehaviour
{
    public string pickUpTag = "PickUp";  
    public Transform BackTo;
    public GameObject resetText;
    public GameObject Text;                    
    public Transform player;                  
    public float interactionRange = 3f;       

    private Dictionary<GameObject, Vector3> initialPositions = new Dictionary<GameObject, Vector3>();
    private bool playerInRange = false;
    private GameObject currentPickedUpObject;

    void Start()
    {
        GameObject[] pickUpObjects = GameObject.FindGameObjectsWithTag(pickUpTag);
        foreach (GameObject obj in pickUpObjects)
        {
            initialPositions[obj] = obj.transform.position;
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            ResetPickUpPositions();
        }
        if (playerInRange){
            resetText.SetActive(true);
        }else{
            resetText.SetActive(false);
        }
    }

    void ResetPickUpPositions()
    {   
        foreach (var item in initialPositions)
        {
            item.Key.transform.position = item.Value;
            item.Key.transform.SetParent(BackTo);
            Rigidbody2D rb2D = item.Key.GetComponent<Rigidbody2D>();
            Collider2D coll2D = item.Key.GetComponent<Collider2D>();
            if (rb2D != null)
            {
                rb2D.isKinematic = false;
            }
            if (coll2D != null)
            {
                coll2D.enabled = true;
            }
        }
    }
    
}
