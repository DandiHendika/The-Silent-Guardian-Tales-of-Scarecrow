using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUltimate : MonoBehaviour
{
    public GameObject fireblastPrefab;    // Prefab untuk fireblast
    public Transform firePoint;          // Posisi spawn fireblast
    public GameObject bubbleText;              // Dialog UI Text
    public float dialogDuration = 2f;    // Durasi dialog
    public float fireblastDuration = 3f; // Durasi fireblast muncul
    public int fireblastDamage = 10;     // Damage fireblast
    public float projectileCooldown = 15f; 
    private float lastProjectileTime;

    private Bosscontrollers projectileAttack;
    Rigidbody2D rb;
    Bosscontrollers script;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileAttack = GetComponent<Bosscontrollers>(); // Ambil skrip proyektil bos
    }

    void Update()
    {
        if (Time.time >= lastProjectileTime + projectileCooldown && !projectileAttack.isPerformingUltimate) // Trigger ultimate (ganti dengan kondisi lain)
        {
            StartCoroutine(PerformUltimate());
            lastProjectileTime = Time.time; 
        }
    }

    IEnumerator PerformUltimate()
    {
        projectileAttack.isPerformingUltimate = true;

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        // 1. Diam sejenak
        yield return new WaitForSeconds(1f); // Diam selama 1 detik

        // 2. Munculkan bubble text
        // bubbleText.text = "Aku adalah orang yang akan melihat dunia terbakar!";
        bubbleText.gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogDuration); // Durasi dialog
        bubbleText.gameObject.SetActive(false);

        // 3. Semburkan fireblast
        SoundManager.Instance.PlaySound2D("bossdie");
        GameObject fireblast = Instantiate(fireblastPrefab, firePoint.position, firePoint.rotation);
        fireblast.transform.localScale = new Vector3(transform.localScale.x > 0 ? 1 : -1, 1, 1); // Arah fireblast sesuai orientasi bos

        // Beri damage jika pemain terkena
        Fireblast fireblastScript = fireblast.GetComponent<Fireblast>();
        if (fireblastScript != null)
        {
            fireblastScript.damage = fireblastDamage;
        }

        yield return new WaitForSeconds(fireblastDuration); // Durasi fireblast di layar
        Destroy(fireblast); // Hancurkan fireblast

        // 4. Kembali ke state normal
        projectileAttack.isPerformingUltimate = false;

        rb.constraints = RigidbodyConstraints2D.None;
    }
}

