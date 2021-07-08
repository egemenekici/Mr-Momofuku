using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //UI
    [SerializeField] public Image[] health;
    public TextMeshProUGUI textGravity;
    public TextMeshProUGUI textGems;
    public TextMeshProUGUI textAmmo;

    public bool isImmune = false;

    public int heart = 4;
    public int maxAmmo = 10;
    public int ammo = 10;
    public int gemCount = 22;
    public int maxHeart = 4;
    public int maxGravity = 10;
    public int gravityCount = 10;
    
    
    public void Damage(int amount)
    {
        if (!isImmune) {
        health[heart - 1].enabled = false;
        heart -= amount;
        FindObjectOfType<movement>().dontMove();
        gravityCount = PlayerPrefs.GetInt("MaxGravity");
        ammo = PlayerPrefs.GetInt("AmmoCount");
        textGravity.text = gravityCount.ToString();
        textAmmo.text = ammo.ToString();

            if (heart == 0)
            {
            FindObjectOfType<LevelManager>().Restart();
            }

            else
            {

            FindObjectOfType<LevelManager>().resetPos();
            }
        }
    }


    public IEnumerator Immune()
    {
        //Debug.Log(isImmune);
        isImmune = true;
        yield return new WaitForSeconds(5);
        isImmune = false;
        //Debug.Log(isImmune);


    }

    public void fallDamage(int amount)
    {
        health[heart - 1].enabled = false;
        heart -= amount;
        FindObjectOfType<movement>().dontMove();
        gravityCount = PlayerPrefs.GetInt("MaxGravity");
        ammo = PlayerPrefs.GetInt("AmmoCount");
        textGravity.text = gravityCount.ToString();
        textAmmo.text = ammo.ToString();

        if (heart == 0)
        {
            FindObjectOfType<LevelManager>().Restart();
        }
        else
        {

            FindObjectOfType<LevelManager>().resetPos();
        }
    }


    public void gravityUsed()
    {
        gravityCount -= 1;
        textGravity.text = gravityCount.ToString();
    }
    public void ammoUsed()
    {
        ammo -= 1;
        textAmmo.text = ammo.ToString();
    }

    public void refillGravity()
    {
     
        gravityCount = maxGravity;
        textGravity.text = gravityCount.ToString();

    }

    public void refillAmmo()
    {
        ammo = maxAmmo;
        textAmmo.text = ammo.ToString();
    }
    
    public void renewText()
    {
        textGravity.text = gravityCount.ToString();
        textGems.text = gemCount.ToString();
        textAmmo.text = ammo.ToString();
    }

    public void Regen()
    {
        heart = maxHeart;
        for(int i=0; i<maxHeart; i++)
        {
            health[i].enabled = true;
        }
    }

    public void keepHp(int dummy)
    {
        for (int i = 0; i < dummy; i++)
        {
            health[i].enabled = true;
        }
    }
    public void GemCollected()
    {
        gemCount += 1;
        textGems.text = gemCount.ToString();

    }

    private void Start()
    {
        heart = 0;
        health[0].enabled = false;
        health[1].enabled = false;
        health[2].enabled = false;
        health[3].enabled = false;
        health[4].enabled = false;
        health[5].enabled = false;

        //maxHeart = 2;
        maxHeart = PlayerPrefs.GetInt("MaxHp");
        gemCount = PlayerPrefs.GetInt("GemCount");
        maxAmmo = PlayerPrefs.GetInt("MaxAmmo");
        ammo = PlayerPrefs.GetInt("AmmoCount");
        maxGravity = PlayerPrefs.GetInt("MaxGravity");
        gravityCount = maxGravity;
        heart = PlayerPrefs.GetInt("HpCount");
        renewText();
        keepHp(heart);
    }
    private void Update()
    {
        if(heart > maxHeart)
        {
            heart = maxHeart;
        }

       

        if (gravityCount < 0)
        {
            gravityCount = 0;
        }

        if(ammo < 0)
        {
            ammo = 0;
        }


    }
}
