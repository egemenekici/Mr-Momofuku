using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectArmor : MonoBehaviour
{
    bool canActivate = true;
    public  TextMeshProUGUI textSeconds;
    Vector3 scaler;
    public SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = true;
      //  textSeconds.enabled = false;
    }
    public IEnumerator Immune()
    {

        FindObjectOfType<CharacterStats>().isImmune = true;
        textSeconds.enabled = true;
        textSeconds.text = "IMMUNTY! 3";
        yield return new WaitForSeconds(1.0f);
        textSeconds.text = "IMMUNTY! 2";
        yield return new WaitForSeconds(1.0f);
        textSeconds.text = "IMMUNTY! 1";
        yield return new WaitForSeconds(1.0f);
        textSeconds.enabled = false;
        FindObjectOfType<CharacterStats>().isImmune = false;
        canActivate = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canActivate)
        {
            canActivate = false;
            renderer.enabled = false;
            StartCoroutine(Immune());

        }

    }
}
