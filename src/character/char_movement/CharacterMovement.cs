using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool onGround = true;
    //bool canJump = true;      //DOUBLE JUMP
    bool faceRight = true;
    bool faceUp = true;
    bool Wpress = false;
    bool Spress = false;

    public float speed=10;
    public float jumpspeed=600;

    float moveInput;
    float jumpInput;

    Rigidbody2D rb;
    Animator animator;
    CharacterStats cs;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 5;
        animator = GetComponent<Animator>();
        cs = GetComponent<CharacterStats>();
        cs.isImmune = false;
        speed = PlayerPrefs.GetFloat("maxSpeed");
        jumpspeed = PlayerPrefs.GetFloat("maxJmpSpd");
        
    }

    public void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        Wpress = Input.GetKeyDown(KeyCode.W);
        Spress = Input.GetKeyDown(KeyCode.S);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (jumpInput != 0)
        {
            Jump();
        }

        animator.SetBool("isRunning", (moveInput != 0));

        //      GRAVITY TERS-DUZ
        if (Wpress && faceUp && cs.gravityCount > 0)
        {
            cs.gravityUsed();
            FlipY();
            animator.SetBool("isJumping", true);
        }

        if (Spress && !faceUp && cs.gravityCount > 0)
        {
            cs.gravityUsed();
            FlipY();
            animator.SetBool("isJumping", true);
        }

        if (faceRight && moveInput < 0)
        {
            FlipX();
        }

        else if (!faceRight && moveInput > 0)
        {
            FlipX();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            onGround = true;
            //canJump = true;       //DOUBLE JUMP
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CollectableHP" && cs.heart != cs.maxHeart)
        {
            cs.Regen();
            Destroy(collision.gameObject);

        }
    }


    private void Jump()
    {
        if(onGround)
        {
            isJumping();
            onGround = false;

        }

        //  DOUBLE JUMP
 /*       else if (canJump)
        {
            isJumping();
            canJump = false;
        }  
 */
    }

    private void OnLevelWasLoaded(int level)
    {
        
        FindObjectOfType<LevelManager>().resetPos2();
    }

    public void isJumping()
    {
        rb.AddForce(Vector2.up * jumpspeed);
        animator.SetBool("isJumping", true);
        
    }

    private void FlipX()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void FlipY()
    {
        rb.gravityScale = rb.gravityScale * -1;
        faceUp = !faceUp;
        Vector3 scaler = transform.localScale;
        scaler.y *= -1;
        transform.localScale = scaler;
        jumpspeed *= -1;
    }
    public bool CheckFaceup()
    { 
        return faceUp;
    }

    public void dontMove() {
       rb.velocity = new Vector2(0,0);

    }


}
