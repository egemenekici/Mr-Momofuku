using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            FindObjectOfType<CharacterStats>().Damage(1);
        }
    }
}
