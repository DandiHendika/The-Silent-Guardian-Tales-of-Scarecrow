using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUltimate : MonoBehaviour
{
    public GameObject fireblastPrefab;    
    public Transform firePoint;          
    public GameObject bubbleText;              
    public float dialogDuration = 2f;    
    public float fireblastDuration = 3f; 
    public int fireblastDamage = 10;     
    public float projectileCooldown = 15f; 
    private float lastProjectileTime;
    private Bosscontrollers projectileAttack;
    Rigidbody2D rb;
    Bosscontrollers script;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileAttack = GetComponent<Bosscontrollers>(); 
    }

    void Update()
    {
        if (Time.time >= lastProjectileTime + projectileCooldown && !projectileAttack.isPerformingUltimate) 
        {
            StartCoroutine(PerformUltimate());
            lastProjectileTime = Time.time; 
        }
    }

    IEnumerator PerformUltimate()
    {
        projectileAttack.isPerformingUltimate = true;

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
 
        yield return new WaitForSeconds(1f); 

        bubbleText.gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogDuration); 
        bubbleText.gameObject.SetActive(false);

        SoundManager.Instance.PlaySound2D("bossdie");
        GameObject fireblast = Instantiate(fireblastPrefab, firePoint.position, firePoint.rotation);
        fireblast.transform.localScale = new Vector3(transform.localScale.x > 0 ? 1 : -1, 1, 1); 
    
        Fireblast fireblastScript = fireblast.GetComponent<Fireblast>();
        if (fireblastScript != null)
        {
            fireblastScript.damage = fireblastDamage;
        }

        yield return new WaitForSeconds(fireblastDuration); 
        Destroy(fireblast); 

        projectileAttack.isPerformingUltimate = false;

        rb.constraints = RigidbodyConstraints2D.None;
    }
}

