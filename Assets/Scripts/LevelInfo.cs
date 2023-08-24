using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    private Statistic statistic;

    [SerializeField]
    private BattleScript battle;

    [SerializeField]
    private FillField fillField;


    // Start is called before the first frame update
    void Start()
    {
        statistic = Statistic.instanse;
        battle.OnDieEnemy += DieEnemy;
        fillField.OnCheckWord += CheckWord;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DieEnemy()
    {
        statistic.UpdateStatistic("KilledEnemies", 1);
    }

    private void CheckWord(bool isDone)
    {
        if (isDone)
        {
            statistic.UpdateStatistic("FoldedWords", 1);
        }
    }
}
