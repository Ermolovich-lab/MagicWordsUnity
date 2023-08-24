using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField]
    private float healh = 10;

    public float Health { get => healh; }

    private Animator animator;

    [SerializeField]
    private GameObject bullet;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AddHealth(float value)
    {
        if(value > 0)
            healh += value;
    }

    public void RemoveHealth(float value)
    {
        if (value > 0)
        {
            healh -= value;
            Damage();
        }

        if (healh <= 0)
        {
            healh = 0;
            Invoke("Die", 0.5f);
        }  
    }

    public void Attack(float power)
    {
        animator.SetTrigger("attack");
        var positionBullet = gameObject.transform.position;
        var instBullet = Instantiate(bullet, new Vector3(positionBullet.x + 0.5f, positionBullet.y + 1, positionBullet.z), gameObject.transform.rotation);
        var script = instBullet.GetComponent<BulletState>();
        script.direction = new Vector3(1, 0, 0);
        script.power = power;
    }

    private void Damage()
    {
        animator.SetTrigger("hurt");
    }

    private void Die()
    {
        animator.SetTrigger("die");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
