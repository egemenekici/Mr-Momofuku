using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    private float shakeTimeRemaining;
    private float shakePower;
    bool faceUp = true;
    CharacterStats cs;
    // Start is called before the first frame update
    void Start()
    {
       cs = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && faceUp && cs.gravityCount > 0)
        {
            StartShake(.5f, 0.25f);
            faceUp = !faceUp;
        }

        if (Input.GetKeyDown(KeyCode.S) && !faceUp && cs.gravityCount > 0)
        {
            StartShake(.5f, 0.25f);
            faceUp = !faceUp;
        }

    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }
}
