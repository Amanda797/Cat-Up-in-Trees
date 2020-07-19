using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
//public float speed;
//public float jumpForce;
//private float moveInput;

{
    public Pawn pawn;
    private Rigidbody2D rigidbody2D;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //our direction to move
        float direction = 0;
    
        //float horizontal = Input.GetAxis("Horizontal");
        //if player moves left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            
        }
        //if player moves right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            
        }

        //if player isn't pressing left for right
        //pawn.move(horizontal);
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    pawn.health.TakeDamage(10);
        //}

        if (Input.GetKeyDown(KeyCode.L))
        {
            pawn.health.health = 0f;
        }

        


        if (pawn.isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //jump   
            pawn.jump(rigidbody2D);
        }


        if (!pawn.isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //double jump logic here
            if (pawn.doubleJump > 0)
            {
                pawn.jump(rigidbody2D);
            }

            
        }

        



   
        pawn.move(direction);
        
        
    }
}
