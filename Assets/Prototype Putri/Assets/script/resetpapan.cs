using UnityEngine;

public class resetpapan : MonoBehaviour
{
    [SerializeField] private Transform karakter;
    [SerializeField] private papan[] platforms;
    [SerializeField] private Vector3 startPosition;

    private void Start()
    {
        startPosition = karakter.position;
    }

    private void Update()
    {
        if (karakter.position.y < -5)
        {
            ResetPlayerAndPlatforms();
        }
    }

    private void ResetPlayerAndPlatforms()
    {
        karakter.position = startPosition;
        foreach (var platform in platforms)
        {
            platform.ResetPlatform();
        }
    }
}