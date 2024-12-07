using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bosscontrollers : MonoBehaviour
{
    public int maxHealth = 3; 
    public int currentHealth;
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    public float projectileCooldown = 200f; 
    private float lastProjectileTime;
    public Animator animator;
    public bool isPerformingUltimate = false;
    public GameObject clear;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public float dialoguesDuration = 2f;
    private Rigidbody2D rb;
    private BossUltimate bu;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        bu = GetComponent<BossUltimate>();
    }

    void Update()
    {
        
        if (Time.time >= lastProjectileTime + projectileCooldown && !isPerformingUltimate)
        {
            SoundManager.Instance.PlaySound2D("BossAttack");
            animator.SetTrigger("attack_fireball");
            
            lastProjectileTime = Time.time; 
        }
    }
    void FireProjectile()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        
        BossAmmo projectileScript = projectile.GetComponent<BossAmmo>();

        if (transform.localScale.x < 0) 
        {
            projectileScript.speed = Mathf.Abs(projectileScript.speed); 
        }
        else 
        {
            projectileScript.speed = -Mathf.Abs(projectileScript.speed); 
        }
        if (transform.localScale.x < 0) 
        {
            projectile.transform.localScale = new Vector3(-1, 1, 1); 
        }
    }

    void ultimate(){
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        
        BossAmmo projectileScript = projectile.GetComponent<BossAmmo>();
        if (transform.localScale.x < 0) 
        {
            projectileScript.speed = Mathf.Abs(projectileScript.speed); 
        }
        else 
        {
            projectileScript.speed = -Mathf.Abs(projectileScript.speed); 
        }
        if (transform.localScale.x < 0) 
        {
            projectile.transform.localScale = new Vector3(-1, 1, 1); 
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0){
        animator.SetTrigger("Hit"); 
        }else
        {
            Die();
        }
    }

    void Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        StartCoroutine(ShowDialogues());
    }

    private IEnumerator ShowDialogues()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        bu.enabled = false;
        dialog1.gameObject.SetActive(true);
       
        yield return new WaitForSeconds(dialoguesDuration);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(dialoguesDuration);
        dialog2.gameObject.SetActive(false);
        dialog3.gameObject.SetActive(true);
        SoundManager.Instance.PlaySound2D("BossAttackUltimate");
        animator.SetTrigger("die");
        yield return new WaitForSeconds(dialoguesDuration);
        SoundManager.Instance.PlaySound2D("Win");
        clear.gameObject.SetActive(true);
        Destroy(gameObject);

    }

    public void AudioAttack(){
        SoundManager.Instance.PlaySound2D("BossAttack");
    }
}
