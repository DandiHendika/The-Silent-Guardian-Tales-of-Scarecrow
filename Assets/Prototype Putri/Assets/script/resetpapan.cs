using UnityEngine;

public class resetpapan : MonoBehaviour
{
    [SerializeField] private Transform Karakter;
    [SerializeField] private papan[] platforms;
    [SerializeField] private Vector3 startPosition;

    private void Start()
    {
        startPosition = Karakter.position;
    }

    private void Update()
    {
        if (Karakter.position.y < -5)
        {
            ResetPlayerAndPlatforms();
        }
    }

    private void ResetPlayerAndPlatforms()
    {
        Karakter.position = startPosition;
        foreach (var platform in platforms)
        {
            platform.ResetPlatform();
        }
    }
}