using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private karakter karakter;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake(){
        anim = GetComponent<Animator>();
        karakter = GetComponent<karakter>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.B) && cooldownTimer > attackCooldown){
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        // anim.SetTrigger("Attack");
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].transform.rotation = firePoint.rotation;
        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
