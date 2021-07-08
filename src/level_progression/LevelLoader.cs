using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int levelTag = 2;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {

            PlayerPrefs.SetInt("MaxHp", FindObjectOfType<CharacterStats>().maxHeart);
            PlayerPrefs.SetInt("MaxGravity", FindObjectOfType<CharacterStats>().maxGravity);
            PlayerPrefs.SetInt("MaxAmmo", FindObjectOfType<CharacterStats>().maxAmmo);
            PlayerPrefs.SetInt("AmmoCount", FindObjectOfType<CharacterStats>().ammo);
            PlayerPrefs.SetInt("GemCount", FindObjectOfType<CharacterStats>().gemCount);
            PlayerPrefs.SetInt("HpCount", FindObjectOfType<CharacterStats>().heart);
            PlayerPrefs.SetFloat("maxSpeed", FindObjectOfType<movement>().speed);
            PlayerPrefs.SetFloat("maxJmpSpeed", FindObjectOfType<movement>().jumpspeed);
            PlayerPrefs.SetFloat("lastposX", -7.7f);
            PlayerPrefs.SetFloat("lastposY", 2.76f);

            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levelTag); 
    }
}
