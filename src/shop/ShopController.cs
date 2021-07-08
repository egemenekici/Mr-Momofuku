using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{

    public int moneyAmount;

    public bool maxhpsold;
    public bool maxspdsold;
    public bool recohpsold;
    public bool recoammosold;
    public bool maxgrasold;
    public bool maxjumpsold;


    public TextMeshProUGUI maxHpUp;
    public TextMeshProUGUI maxSpdUp;
    public TextMeshProUGUI recoveryHp;
    public TextMeshProUGUI recoveryAmmo;
    public TextMeshProUGUI maxGravUp;
    public TextMeshProUGUI maxJumpUp;
    public TextMeshProUGUI moneyAmountText;

    
    public Button BmaxHpUp;
    public Button BmaxSpdUp;
    public Button BrecoveryHp;
    public Button BrecoveryAmmo;
    public Button BmaxGravUp;
    public Button BmaxJumpUp;
    public Button Exit;

    
    public Image maxHpImage;
    public Image maxSpdImage;
    public Image recoHpImage;
    public Image recoAmmoImage;
    public Image maxGravImage;
    public Image maxJumpImage;

    public void recoverAmmo()
    {

        int dummy = PlayerPrefs.GetInt("MaxAmmo");

        if (dummy < 20)
        {


            if (moneyAmount >= int.Parse(recoveryAmmo.text) && !recoammosold)
            {
                moneyAmount -= int.Parse(recoveryAmmo.text);
                recoveryAmmo.text = "SOLD OUT!";
                recoAmmoImage.enabled = false;
                recoammosold = true;
                PlayerPrefs.SetInt("MaxAmmo", dummy + 5);
                PlayerPrefs.SetInt("AmmoCount", PlayerPrefs.GetInt("MaxAmmo"));
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }
        }


    }

    public void recoverHp()
    {
       
        
            if (moneyAmount >= int.Parse(recoveryHp.text) && !recohpsold)
            {
                moneyAmount -= int.Parse(recoveryHp.text);
                recoveryHp.text = "SOLD OUT!";
                recoHpImage.enabled = false;

                recohpsold = true;
                PlayerPrefs.SetInt("HpCount", PlayerPrefs.GetInt("MaxHp"));
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }

        
       
    }




    public void BuyMaxHp()
    {
        int dummy = PlayerPrefs.GetInt("MaxHp");
        if (dummy < 6)
        {
            if (moneyAmount >= int.Parse(maxHpUp.text) && !maxhpsold)
            {
                moneyAmount -= int.Parse(maxHpUp.text);
                maxHpUp.text = "SOLD OUT!";
                maxHpImage.enabled = false;

                maxhpsold = true;
                dummy += 1;
                PlayerPrefs.SetInt("MaxHp", dummy);
                PlayerPrefs.SetInt("HpCount", dummy);
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }

        }
        else
        {
            maxHpUp.text = "REACHED CAPACITY";
        }
    }

    public void BuyMaxGrav()
    {
        int dummy = PlayerPrefs.GetInt("MaxGravity");
        if (dummy < 20)
        {
            if (moneyAmount >= int.Parse(maxGravUp.text) && !maxgrasold)
            {
                moneyAmount -= int.Parse(maxGravUp.text);
                maxGravUp.text = "SOLD OUT!";
                maxGravImage.enabled = false;

                maxgrasold = true;
                dummy += 5;
                PlayerPrefs.SetInt("MaxGravity", dummy);
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }

        }
        else
        {
            maxGravUp.text = "REACHED CAPACITY";
        }
    }



    public void BuyMaxSpd()
    {
        float dummy = PlayerPrefs.GetFloat("maxSpeed");
        if (dummy < 16)
        {
            if (moneyAmount >= int.Parse(maxSpdUp.text) && !maxspdsold)
            {
                moneyAmount -= int.Parse(maxSpdUp.text);
                maxSpdUp.text = "SOLD OUT!";
                maxSpdImage.enabled = false;

                maxspdsold = true;
                dummy += 3;
                PlayerPrefs.SetFloat("maxSpeed", dummy);
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }

        }
        else
        {
            maxSpdUp.text = "REACHED CAPACITY";
        }
    }

    public void BuyMaxJmp()
    {
        float dummy = PlayerPrefs.GetFloat("maxJmpSpd");
        if (dummy < 760)
        {
            if (moneyAmount >= int.Parse(maxJumpUp.text) && !maxjumpsold)
            {
                moneyAmount -= int.Parse(maxJumpUp.text);
                maxJumpUp.text = "SOLD OUT!";
                maxJumpImage.enabled = false;

                maxjumpsold = true;
                dummy += 80;
                PlayerPrefs.SetFloat("maxJmpSpd", dummy);
                PlayerPrefs.SetInt("GemCount", moneyAmount);
            }

        }
        else
        {
            maxJumpUp.text = "REACHED CAPACITY";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("GemCount");
        maxhpsold = false;
        maxspdsold = false;
        recohpsold = false;
        recoammosold = false;
        maxgrasold = false;
        maxjumpsold = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
    }
}
