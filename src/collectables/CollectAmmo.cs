using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FindObjectOfType<CharacterStats>().ammo != FindObjectOfType<CharacterStats>().maxAmmo)
            {

                FindObjectOfType<CharacterStats>().refillAmmo();

                Destroy(gameObject);
            }

        }

    }
}
