using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public abstract class AbstractLevel : MonoBehaviour
{
    public BattleScript battle;
    public EnemyManager enemyManager;
    [HideInInspector]
    public FillField fillField;
    protected List<Word> words;
    public TextMeshProUGUI level;
    public TextMeshProUGUI timer;

    public TextMeshProUGUI end;
    public GameObject panel;

    public float roundDamage = 10;

    [SerializeField]
    private MoveTimerController timerController;

    [SerializeField]
    private HintsLauncher hintsLauncher;

    [SerializeField]
    private ProgressBar progressBar;

    protected abstract void initWords();    

    // Start is called before the first frame update
    void Start()
    {
        fillField = FillField.instance;
        initWords();
        battle.SetEnemy(enemyManager.currEnemy);
        battle.OnDieEnemy += DieEnemy;
        battle.OnDiePlayer += DiePlayer;

        fillField.SetWords(words);
        fillField.Fill();

        timerController.ResetTime();
        timerController.StopTime();

        progressBar.maximum = fillField.freeWorldCount;

        hintsLauncher.OpenForWhile(3);

        Invoke("StartGame", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (battle.IsAttacks) return;

        timer.text = string.Format("{0:f1}", timerController.MoveTimer - timerController.CurrTime) + "s";

        if (enemyManager.isEnd)
        {
            end.text = "You win!";
            panel.SetActive(true);
            UnlockedLevelController.instance.UnlockedNextLevel();
            enabled = false;
        }

        if (fillField.freeWorldCount == 0)
        {
            DiePlayer();
        }

        if (timerController.IsTimeOver)
        {
            PlayGame();
        }

        progressBar.current = fillField.freeWorldCount;
    }

    private void StartGame()
    {
        timerController.PlayTime();
        level.text = "level: " + enemyManager.numbEnemy + "/" + enemyManager.CountEnemyOnLevel;
    }

    private void NextLevel()
    {
        enemyManager.NextEnemy();
        timerController.PlayTime();
        battle.SetEnemy(enemyManager.currEnemy);
        battle.ResetButtle();

        level.text = "level: " + enemyManager.numbEnemy + "/" + enemyManager.CountEnemyOnLevel;
    }

    public void PlayGame()
    {
        if (!battle.IsPlayGame) return;

        float oneHit = roundDamage / fillField.usedWordsCount;
        float playerDamage = fillField.notUsedWords * oneHit;
        float enemyDamage = (fillField.usedWordsCount - fillField.notUsedWords) * oneHit;

        battle.Attacks(playerDamage + 1, enemyDamage + 1);
        
        fillField.Fill();
        timerController.ResetTime();

        if (enemyManager.numbEnemy < enemyManager.ememies.Count)
            hintsLauncher.OpenForWhile(3);
    }

    private void DiePlayer()
    {
        end.text = "You die!";
        panel.SetActive(true);
    }

    private void DieEnemy()
    {
        timerController.ResetTime();
        timerController.StopTime();
        Invoke("NextLevel", 4);
    }
}
