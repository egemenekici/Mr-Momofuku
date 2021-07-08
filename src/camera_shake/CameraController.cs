using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;
    private float startY;
    int direction = 3;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 3;
        }

  /*      if (Input.GetKeyDown(KeyCode.A))
        {
            
            direction = -3;
        } */

        if (target != null)
        {
            transform.position = new Vector3(target.position.x+direction, startY, transform.position.z);
        }
    }
}
