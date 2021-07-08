using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Vector2 playerPos;

    private void Start()
    {
        playerPos.x = PlayerPrefs.GetFloat("lastposX");
        playerPos.y = PlayerPrefs.GetFloat("lastposY");
    }
    public void Restart()
    {

        // bütün playerprefs leri sýfýrla
        PlayerPrefs.SetInt("Shop1", 1);
        PlayerPrefs.SetInt("Shop2", 1);
        PlayerPrefs.SetInt("Shop3", 1);
        PlayerPrefs.SetInt("SceneTag", SceneManager.GetActiveScene().buildIndex);
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

        SceneManager.LoadScene(8);
    }
    
    public void resetPos()
    {
        if (!FindObjectOfType<movement>().CheckFaceup())
        {
            FindObjectOfType<movement>().FlipY();
        }

        FindObjectOfType<movement>().transform.position = playerPos;
    }

    public void resetPos2()
    {

        FindObjectOfType<movement>().transform.position.Set(-6.8f, 7f, 0f);
    }

    public void setPlayerPos(Vector2 dummyVec2)
    {
        playerPos = dummyVec2;
    }
}
