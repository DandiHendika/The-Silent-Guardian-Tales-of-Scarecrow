using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] GameObject Overmenu;
    public float currentHealth { get; private set; }
    private Animator anim; 
    Rigidbody2D rb;
    public GameObject mnObj;
    private void Awake(){
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0){
            anim.SetTrigger("Hurt");
        }else{
            MainMenu mn = mnObj.GetComponent<MainMenu>();
            mn.isGameover = true; 
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Collider2D collider = GetComponent<Collider2D>();
            SoundManager.Instance.PlaySound2D("Lose");
            if (collider != null)
            {
                collider.enabled = false;
            }
            anim.SetTrigger("Die");
        }
    }

    private void Gameover(){
        Overmenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update(){
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    

}
