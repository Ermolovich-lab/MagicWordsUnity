using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public float power;
    public Vector3 direction;
    public float speed;

    public string target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (power <= 0)
        {
            Destroy(gameObject);
        }
    }
}
