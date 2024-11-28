using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class karakter : MonoBehaviour
{
    public float speed;
    public float jump;
    Rigidbody2D body;
    SpriteRenderer sprite;
    private Vector3 startPosition;
    private Vector3 checkpointPosition;
    [SerializeField] private Text finishText;
    [SerializeField] private TMP_Text HideText;
    private bool isHiding = false;
    private GameObject HideSpot;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip walkingSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        checkpointPosition = startPosition;
        if (finishText != null)
        {
            finishText.gameObject.SetActive(false);
        }
        if (HideText != null)
        {
            HideText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float horizontal = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
            sprite.flipX = true;
        }

        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        bool Walking = horizontal != 0;

        animator.SetBool("Walking", Walking);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jump);
        }

        if (transform.position.y < -5f)
        {
            ResetPosition();
        }

        if (HideSpot != null && Input.GetKeyDown(KeyCode.E))
        {
            ToggleHide();
        }

        if (Walking && !audioSource.isPlaying)
        {
            audioSource.clip = walkingSound;
            audioSource.Play();
        }
        else if (!Walking && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void ToggleHide()
    {
        isHiding = !isHiding;

        if (isHiding)
        {
            sprite.enabled = false;
            body.velocity = Vector2.zero;
            body.isKinematic = true;
        }
        else
        {
            sprite.enabled = true;
            body.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetPosition();
        }
        if (collision.gameObject.CompareTag("Saw"))
        {
            ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPosition = transform.position;
            Debug.Log("Checkpoint reached!");
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish reached!");
        }
        if (other.CompareTag("HideSpot"))
        {
            HideSpot = other.gameObject;
            if (HideText != null)
            {
                HideText.gameObject.SetActive(true);
                Debug.Log("Teks muncul: Tekan E untuk sembunyi");
            }
            else
            {
                Debug.LogWarning("HideText belum dihubungkan di Inspector!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
        {
            HideSpot = null;

            if (isHiding)
            {
                ToggleHide();
                if (HideText != null)
                {
                    HideText.gameObject.SetActive(false);
                }
            }
        }
    }

    private void ResetPosition()
    {
        Debug.Log("Resetting position to checkpoint: " + checkpointPosition);
        transform.position = checkpointPosition;
        body.velocity = Vector2.zero;
    }
}
