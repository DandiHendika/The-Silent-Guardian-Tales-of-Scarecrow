using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class WaterReflection : MonoBehaviour
{
    public Camera reflectionCameraPrefab; // Kamera refleksi prefab (drag & drop)
    private Camera reflectionCamera;
    private RenderTexture reflectionTexture;

    void Start()
    {
        // Buat kamera refleksi sebagai child
        if (reflectionCameraPrefab != null)
        {
            reflectionCamera = Instantiate(reflectionCameraPrefab, transform);
            reflectionCamera.gameObject.name = "ReflectionCamera";
        }

        // Buat render texture untuk refleksi
        reflectionTexture = new RenderTexture(Screen.width, Screen.height, 16);
        reflectionCamera.targetTexture = reflectionTexture;

        // Sambungkan texture ke material air
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.SetTexture("_ReflectionTex", reflectionTexture);
    }

    void Update()
    {
        if (reflectionCamera != null)
        {
            UpdateReflectionCamera();
        }
    }

    void UpdateReflectionCamera()
    {
        // Sinkronkan posisi dan rotasi kamera refleksi
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            Vector3 cameraDirection = mainCamera.transform.forward;
            reflectionCamera.transform.position = transform.position - cameraDirection;
            reflectionCamera.transform.rotation = Quaternion.LookRotation(-cameraDirection, Vector3.up);

            // Perbarui proyeksi kamera refleksi
            reflectionCamera.Render();
        }
    }

    void OnDestroy()
    {
        // Hapus render texture saat objek dihancurkan
        if (reflectionTexture != null)
        {
            reflectionTexture.Release();
        }
    }
}

