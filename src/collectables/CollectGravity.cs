using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGravity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FindObjectOfType<CharacterStats>().gravityCount != FindObjectOfType<CharacterStats>().maxGravity)
            {

                FindObjectOfType<CharacterStats>().refillGravity();

                Destroy(gameObject);
            }
        
        }

    }
}
