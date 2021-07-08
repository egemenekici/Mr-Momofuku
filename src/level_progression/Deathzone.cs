using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{

    CharacterStats cs;

    private void Start()
    {
        cs = GetComponent<CharacterStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DeathZone" && cs.heart > 0 )
        {
            cs.fallDamage(1);

        }
    }
}
