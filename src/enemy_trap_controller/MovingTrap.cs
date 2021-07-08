using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTrap : MonoBehaviour
{
    public float walkSpeed = -40;

    public Rigidbody2D rb;
    public Transform groundCheckPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Patrol();
    }


    void Patrol()
    {
        rb.velocity = new Vector2(rb.velocity.x, walkSpeed * Time.fixedDeltaTime);
    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
        walkSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            FindObjectOfType<CharacterStats>().Damage(1);
        }
    }
}