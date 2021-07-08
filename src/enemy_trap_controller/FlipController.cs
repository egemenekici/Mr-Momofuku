using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipscript : MonoBehaviour
{

        private void OnTriggerEnter2D(Collider2D collision)
        {


            if (collision.tag == ("flipTrap"))
            {
                transform.parent.gameObject.GetComponent<movingTrap>().Flip();
            }
        }
}
