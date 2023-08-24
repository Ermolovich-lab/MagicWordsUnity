using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    private BulletState bulletState;

    public GameObject collisionEffect;

    public bool isOnlyPlayableCharacter = false;

    public string target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isOnlyPlayableCharacter && collision.gameObject.tag == "Bullet")
        {
            var enemyState = collision.gameObject.GetComponent<BulletState>();

            var temp = bulletState.power;
            bulletState.power -= enemyState.power;
            enemyState.power -= temp;

            Instantiate(collisionEffect, (Vector3)collision.contacts[0].point, collisionEffect.transform.rotation);
        }
        else if(collision.gameObject.tag == target)
        {
            var health = collision.gameObject.GetComponent<IHealth>();
            health.RemoveHealth(bulletState.power);

            Destroy(gameObject);
        }
    }
}
