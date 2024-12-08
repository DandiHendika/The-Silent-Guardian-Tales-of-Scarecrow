using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyVision : MonoBehaviour
{
    public float detectionRange = 5f; 
    public LayerMask playerLayer;    
    public GameObject gameOverScene;

    public Vector2 offset = new Vector2(2f, 0f); 
    private SpriteRenderer spriteRenderer;      
    public Rigidbody2D rb;
    public GameObject mnObj;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector3 visionPosition = GetVisionPosition();
        Collider2D detectedPlayer = Physics2D.OverlapCircle(visionPosition, detectionRange, playerLayer);

        if (detectedPlayer != null)
        { 
            GameOver();
        }
    }

    Vector3 GetVisionPosition()
    {
        float direction = spriteRenderer.flipX ? -1 : 1; 
        return transform.position + new Vector3(offset.x * direction, offset.y, 0);
    }

    private void GameOver()
    {
        MainMenu mn = mnObj.GetComponent<MainMenu>();
        mn.isGameover = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
        gameOverScene.gameObject.SetActive(true);
        
        Time.timeScale = 0f;
    }

    
    void OnDrawGizmosSelected()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        Gizmos.color = Color.red;
        Vector3 visionPosition = GetVisionPosition();
        Gizmos.DrawWireSphere(visionPosition, detectionRange);
    }
}

