using UnityEngine;
using System.Collections;

public class Papan : MonoBehaviour
{
    [SerializeField] private float delayBeforeDisappear = 3f; 
    [SerializeField] private float appearDelay = 2f; 

    private Vector3 initialPosition;
    private bool isActive = true;
    private Collider2D platformCollider;
    private SpriteRenderer platformRenderer;

    private void Start()
    {
        initialPosition = transform.position;
        platformCollider = GetComponent<Collider2D>(); 
        platformRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            StartCoroutine(DisappearAfterDelay());
            ResetPlatform();
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);
        
        platformCollider.enabled = false;
        platformRenderer.color = new Color(platformRenderer.color.r, platformRenderer.color.g, platformRenderer.color.b, 0f); 
        
        yield return new WaitForSeconds(appearDelay);

        platformCollider.enabled = true;
        platformRenderer.color = new Color(platformRenderer.color.r, platformRenderer.color.g, platformRenderer.color.b, 1f); 
    }

    public void ResetPlatform()
    {
        transform.position = initialPosition;
        isActive = true;
    }

    public void DisablePlatform()
    {
        isActive = false;
    }
}
