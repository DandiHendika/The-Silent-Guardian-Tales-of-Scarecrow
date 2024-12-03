using UnityEngine;
using System.Collections;

public class papan : MonoBehaviour
{
    [SerializeField] private float delayBeforeDisappear = 3f;
    private Vector3 initialPosition;
    private bool isActive = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive || collision.gameObject.CompareTag("Player") && isActive)
        {
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);
        gameObject.SetActive(false);
    }

    public void ResetPlatform()
    {
        gameObject.SetActive(true);
        transform.position = initialPosition;
        isActive = true;
    }

    public void DisablePlatform()
    {
        isActive = false;
    }
}
