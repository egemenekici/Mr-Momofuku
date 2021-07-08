using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiflipper : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == ("flipEnemy"))
        {
                transform.parent.gameObject.GetComponent<AIPatrol>().Flip();
              
                transform.parent.gameObject.GetComponent<AIPatrol>().walkSpeed *= -1;
            
        }
    }


}
