using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pawn : MonoBehaviour

{
    [Header("Audio")]
    public AudioClip hitSFX;
    public AudioClip deathSFX;

    public float speed;
    public float jumpSpeed;
    public BoxCollider2D boxCollider;
    public LayerMask layerMask;
    [HideInInspector] public int doubleJump;
    public int maxJumps;
    public Transform lastCheckpoint;
    private Animator animator;

    public AudioSource audioSource;
    public Health health;
    private void Start()
    {
        doubleJump = maxJumps;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        health = GetComponent<Health>();

    }
    public void move(float direction)
    {
        if(direction != 0f)
        {
            if (this.gameObject.GetComponent < Player > ())
            {
                animator.SetBool("IsRunning", true); 
            }

            if(direction < 0)
            {
                direction = -1;
            }
            else if(direction > 0)
            {
                direction = 1;
            }

            Vector3 myScale = transform.localScale;
            myScale.x = direction;
            transform.localScale = myScale;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        Vector3 playerPosition = transform.position;
        playerPosition += transform.right * direction * speed * Time.deltaTime;
        transform.position = playerPosition;
    }
    public void jump(Rigidbody2D jumping)
    {
        jumping.velocity = Vector2.up * jumpSpeed;
        doubleJump--;
        animator.SetBool("IsJumping", true);
    }
    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, .2f, layerMask);
        if (hit.collider != null)
        {
            Debug.Log("I should be grounded");
            doubleJump = maxJumps;
            animator.SetBool("IsJumping", false);
            return true;
        }
        else
        {
            return false;
        }
    }
    

}
