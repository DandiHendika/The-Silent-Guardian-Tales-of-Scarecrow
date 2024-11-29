using UnityEngine;

public class audiokarakter: MonoBehaviour
{
    public AudioClip[] footstepSounds; 
    public float stepDelay = 0.2f;

    private AudioSource audioSource;
    private float stepTimer = 0f;
    private bool isWalking = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    { 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isWalking = (horizontal != 0 || vertical != 0);

        if (isWalking)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDelay)
            {
                PlayFootstep();
                stepTimer = 0f; 
            }
        }
        else
        {
            stepTimer = 0f; 
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            AudioClip footstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstep);
        }
    }
}
