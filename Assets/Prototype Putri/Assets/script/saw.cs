using UnityEngine;

public class Saw : MonoBehaviour
{
    public float upperLimit = 3f;
    public float lowerLimit = 1f;
    public float speed = 2f;
    public Transform playerStartPosition;

    private bool movingUp = true;

    void Update()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= upperLimit)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= lowerLimit)
            {
                movingUp = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Karakter"))
        {
            other.transform.position = playerStartPosition.position;
        }
    }
}
