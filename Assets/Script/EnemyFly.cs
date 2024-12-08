using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float followSpeed = 2f; 
    public GameObject eggPrefab; 
    public Transform eggSpawnPoint; 
    public float dropInterval = 2f; 

    private Transform player; 
    private bool isPlayerInRange = false;
    private bool canDropEgg = true;

    void Update()
    {
        if (isPlayerInRange && player != null)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y + 5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    
        if (Mathf.Abs(transform.position.x - player.position.x) < 0.5f)
        {
            DropEgg();
        }
    }

    void DropEgg()
    {
        if (canDropEgg)
        {
            canDropEgg = false;
            Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
            StartCoroutine(ResetDropEgg());
        }
    }

    IEnumerator ResetDropEgg()
    {
        yield return new WaitForSeconds(dropInterval);
        canDropEgg = true;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = collision.transform;
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;
        }
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f); 
    }
}
