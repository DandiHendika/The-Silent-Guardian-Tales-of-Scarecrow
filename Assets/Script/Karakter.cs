using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Karakter : MonoBehaviour
{
    #region Variable
    public float speed;
    public float jumpForce;
    Rigidbody2D body;
    SpriteRenderer sprite;
    private Vector3 startPosition;
    private Vector3 checkpointPosition;
    private bool isGrounded;
    public Transform pickUpPoint;
    public Transform firePoint;
    public Transform BackTo;
    public float pickUpRange = 1.5f;
    private GameObject heldObject = null;
    public LayerMask playerLayer;
    public LayerMask pickedUpLayer; 
    public Vector2 pickUpOffset = new Vector2(0.5f, 0);
    private Animator anim;
    #endregion

    private void Start()
    {
       body = GetComponent<Rigidbody2D>();
       sprite = GetComponent<SpriteRenderer>();
       anim = GetComponent<Animator>();
       startPosition = transform.position;
       checkpointPosition = startPosition;
       UpdatePickUpPoint();
       isGrounded = false;
       
    }

    private void Update()
    {
        #region Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0){
            body.velocity = new Vector2(speed,body.velocity.y);
            sprite.flipX = false;
            UpdatePickUpPoint();
        }else if(horizontalInput < 0){
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
            UpdatePickUpPoint();
        } else {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            anim.SetTrigger("jump");
            isGrounded = false;  
        }
        if (transform.position.y < -40f)
        {
            ResetPosition();
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded);
        #endregion

        #region PickUp
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (heldObject == null)
            {
                anim.SetTrigger("PickUp");
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickUpRange);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("PickUp"))
                    {
                        heldObject = collider.gameObject;
                        heldObject.transform.SetParent(pickUpPoint);
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        heldObject.layer = pickedUpLayer;
                        Collider2D heldCollider = heldObject.GetComponent<Collider2D>();
                         if (heldCollider != null)
                        {
                            heldCollider.enabled = false;
                        }
                        break;
                    }
                }
            }else
            {
                Collider2D heldCollider = heldObject.GetComponent<Collider2D>();
                if (heldCollider != null)
                {
                    heldCollider.enabled = true;
                }
                heldObject.transform.SetParent(BackTo);
                heldObject.GetComponent<Rigidbody2D>().isKinematic = false;
                heldObject.layer = LayerMask.NameToLayer("Default");
                heldObject = null;
            }
        }
        #endregion
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PickUp"))
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PickUp") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            isGrounded = true;
        }else{
            isGrounded = false;
        }
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     TakeDamage();
        // }
    }

    #region CheckPoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPosition = transform.position;
            Debug.Log("Checkpoint reached!");
        }
    }
    private void ResetPosition()
    {
        Debug.Log("Resetting position to checkpoint: " + checkpointPosition);
        transform.position = checkpointPosition;
    }
    #endregion

    private void UpdatePickUpPoint()
    {
        pickUpPoint.localPosition = sprite.flipX ? new Vector3(-pickUpOffset.x, pickUpOffset.y, 0) : new Vector3(pickUpOffset.x, pickUpOffset.y, 0);
    }
}