using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> ememies = new List<GameObject>();
    public Transform spawnPoint;
    public Enemy currEnemy;
    public int numbEnemy = 0;
    public bool isEnd = false;
    public HealthDisplay healthDisplay;

    public int CountEnemyOnLevel = 3;

    public bool isLoop = false;

    private void Awake()
    {
        NextEnemy();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextEnemy()
    {
        if (numbEnemy < CountEnemyOnLevel)
        {
            if(currEnemy != null)
                Destroy(currEnemy.gameObject);

            int index = Random.Range(0, ememies.Count);
            var obj = Instantiate(ememies[index]);
            obj.transform.position = spawnPoint.position;
            currEnemy = obj.GetComponent<Enemy>();
            healthDisplay.Target = obj;
            numbEnemy++;
        }
        else if (isLoop)
        {
            numbEnemy = 0;
            NextEnemy();
        }
        else
            isEnd = true;
        
    }
}
