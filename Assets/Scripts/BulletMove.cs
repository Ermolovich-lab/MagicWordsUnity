using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private BulletState bulletState;

    private bool isFreeze = false;
    private float timer = 0;
    private float timeToFreeze = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFreeze)
        {
            timer += Time.deltaTime;

            if (timer >= timeToFreeze)
            {
                isFreeze = false;
            }
        }

        if (!isFreeze)
        {
            gameObject.transform.position += bulletState.direction * bulletState.speed * Time.deltaTime;
            gameObject.transform.Rotate(new Vector3(0, 0, bulletState.speed * Time.deltaTime * 200));
        }
    }

    public void Freeze()
    {
        isFreeze = true;
        timer = 0;
    }
}
