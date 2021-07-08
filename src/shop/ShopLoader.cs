using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopLoader : MonoBehaviour
{
    public int loadMainScene;
    public int loadStartingScene;
    public int loadShopScene;
    public bool inShop = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player")
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        if (inShop == true)
        {
            inShop = false;
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneTag"));
            
        }
        else
        {
            PlayerPrefs.SetInt("SceneTag", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("MaxHp", FindObjectOfType<CharacterStats>().maxHeart);
            PlayerPrefs.SetInt("MaxGravity", FindObjectOfType<CharacterStats>().maxGravity);
            PlayerPrefs.SetInt("MaxAmmo", FindObjectOfType<CharacterStats>().maxAmmo);
            PlayerPrefs.SetInt("AmmoCount", FindObjectOfType<CharacterStats>().ammo);
            PlayerPrefs.SetInt("GemCount", FindObjectOfType<CharacterStats>().gemCount);
            PlayerPrefs.SetInt("HpCount", FindObjectOfType<CharacterStats>().heart);
            PlayerPrefs.SetFloat("maxSpeed", FindObjectOfType<movement>().speed);
            PlayerPrefs.SetFloat("maxJmpSpeed", FindObjectOfType<movement>().jumpspeed);
            PlayerPrefs.SetFloat("lastposX", FindObjectOfType<LevelManager>().playerPos.x);
            PlayerPrefs.SetFloat("lastposY", FindObjectOfType<LevelManager>().playerPos.y);
            inShop = true;
            
            
            SceneManager.LoadScene(6); 
        }
    }

    public void StartFirstScene()
    {
        PlayerPrefs.SetInt("Shop1", 1);
        PlayerPrefs.SetInt("Shop2", 1);
        PlayerPrefs.SetInt("Shop3", 1);
        PlayerPrefs.SetInt("SceneTag", 0);
        PlayerPrefs.SetInt("MaxHp", 4);
        PlayerPrefs.SetInt("MaxGravity", 10);
        PlayerPrefs.SetInt("MaxAmmo", 10);
        PlayerPrefs.SetInt("AmmoCount", 10);
        PlayerPrefs.SetInt("GemCount", 20);
        PlayerPrefs.SetInt("HpCount", 4);
        PlayerPrefs.SetFloat("maxSpeed", 10.0f);
        PlayerPrefs.SetFloat("maxJmpSpd", 600.0f);
        PlayerPrefs.SetFloat("lastposX", -7.7f);
        PlayerPrefs.SetFloat("lastposY", 2.76f);
        SceneManager.LoadScene(loadStartingScene);
    }
    public void Replay()
    {
        PlayerPrefs.SetInt("Shop1", 1);
        PlayerPrefs.SetInt("Shop2", 1);
        PlayerPrefs.SetInt("Shop3", 1);
        PlayerPrefs.SetInt("MaxHp", 4);
        PlayerPrefs.SetInt("MaxGravity", 10);
        PlayerPrefs.SetInt("MaxAmmo", 10);
        PlayerPrefs.SetInt("AmmoCount", 10);
        PlayerPrefs.SetInt("GemCount", 20);
        PlayerPrefs.SetInt("HpCount", 4);
        PlayerPrefs.SetFloat("maxSpeed", 10.0f);
        PlayerPrefs.SetFloat("maxJmpSpd", 600.0f);
        PlayerPrefs.SetFloat("lastposX", -7.7f);
        PlayerPrefs.SetFloat("lastposY", 2.76f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneTag"));
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(9);
    }
    
  
    
    public void QuittheGame()
    {
        Application.Quit();
    }
}
