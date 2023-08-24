using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCollision : MonoBehaviour
{
    public float timeToSpawn = 0.25f;
    public float timeToLive = 0.5f;
    public float timeToDestroy = 0.25f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy + timeToLive + timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer <= timeToSpawn)
            gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.15f, 0.15f, 0.15f), timer / timeToSpawn);

        if(timer >= timeToLive + timeToSpawn)
        {
            var localTimer = timer - (timeToLive + timeToSpawn);

            gameObject.transform.localScale = Vector3.Lerp(new Vector3(0.15f, 0.15f, 0.15f), new Vector3(0, 0, 0), localTimer / timeToDestroy);
        }
    }
}
