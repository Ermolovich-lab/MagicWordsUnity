using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;

    public Player Player { get => player; }
    public Enemy Enemy { get => enemy; }

    [SerializeField]
    private float timeToAttack = 3;
    private float timer = 0;

    public bool IsAttacks { get; private set; } = false;
    public bool IsPlayGame { get; private set; } = true;

    public Action OnDiePlayer;
    public Action OnDieEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttacks)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                IsAttacks = false;
            }
        }

        if (!IsPlayGame) { return; }

        if (Player.Health <= 0)
        {
            IsPlayGame = false;
            OnDiePlayer?.Invoke();
        }
        else if (Enemy.Health <= 0)
        {
            IsPlayGame = false;
            OnDieEnemy?.Invoke();
        }
    }

    public void SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void ResetButtle()
    {
        IsPlayGame = true;
    }

    public void Attacks(float damageToPlayer, float damageToEnemy)
    {
        enemy.Attack(damageToPlayer);
        player.Attack(damageToEnemy);
        IsAttacks = true;
        timer = 0;
    }
}
