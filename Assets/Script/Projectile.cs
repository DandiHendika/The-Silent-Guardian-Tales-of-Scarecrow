using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake(){
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        SetDirection(1f);
    }

    private void Update(){
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        hit = true;
        boxCollider.enabled = false;
    }

    public void SetDirection(float _direction){
        // direction = _direction;
        // gameObject.SetActive(true);
        // hit = false;
        // boxCollider.enabled = true;

        // float localScaleX = transform.localScale.x;
        // if(Mathf.Sign(localScaleX) != _direction){
        //     localScaleX = -localScaleX;
        // }

        // transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        direction = Mathf.Sign(_direction); // Pastikan _direction hanya -1 atau 1
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Perbarui skala lokal berdasarkan arah
        Vector3 localScale = transform.localScale;
        if (Mathf.Sign(localScale.x) != direction)
        {
            localScale.x = -localScale.x;
        }
        transform.localScale = localScale;
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }

    private void Activate(){
        gameObject.SetActive(true);
    }

}
