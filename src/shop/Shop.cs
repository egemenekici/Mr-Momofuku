using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Shop1", 0);
        }
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("Shop1")== 0)
        {
            Destroy(gameObject);
        }
    }
}
