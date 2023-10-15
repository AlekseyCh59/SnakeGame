using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;



public class GameScript : MonoBehaviour
{
    // Интерфейс
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;

    // Скриптаблы
    public PlayerStats stats;

    Random random = new Random();
    public static bool gameIsPaused = false;

    //Массивы

    [SerializeField] public List<GameObject> SnakeList = new();
    ObjectPool objectpool;
    private float spawnEnemyInterwal = 1;
    private float spawnFoodInterwal = 10;
    private float spawnCoinInterwal = 1;

    public enum Enemies
    {
        EnemyTier1,
        EnemyTier2,
        EnemyTier3,
        EnemyTier4
    }

    private void Init() { 
    stats.maxhp = StatRoot.Player[0].maxhp;
        stats.currentHP = StatRoot.Player[0].maxhp;
        stats.speed = StatRoot.Player[0].speed;
        stats.armor = StatRoot.Player[0].armor;
        stats.phisicresisance = StatRoot.Player[0].phisicresisance;
        stats.magicresisance = StatRoot.Player[0].magicresisance;
        stats.fireresisance = StatRoot.Player[0].fireresisance;
        stats.iceresisance = StatRoot.Player[0].iceresisance;
        stats.lightingresisance = StatRoot.Player[0].lightingresisance;
        stats.shield = StatRoot.Player[0].shield;
        stats.shieldsize = StatRoot.Player[0].shieldsize;
        stats.bonuscooldown = StatRoot.Player[0].bonuscooldown;
        stats.bonusdamage = StatRoot.Player[0].bonusdamage;
        stats.bonusprojectile = StatRoot.Player[0].bonusprojectile;
        stats.bonuscritchance = StatRoot.Player[0].bonuscritchance;
        stats.bonuscritdamage = StatRoot.Player[0].bonuscritdamage;
        stats.bonusfiredamage = StatRoot.Player[0].bonusfiredamage;
        stats.bonusicedamage = StatRoot.Player[0].bonusicedamage;
        stats.bonuslightingdamage = StatRoot.Player[0].bonuslightingdamage;
        stats.bonusmoney = StatRoot.Player[0].bonusmoney;
        stats.bonusexp = StatRoot.Player[0].bonusexp;
        stats.regeneration = StatRoot.Player[0].regeneration;
        stats.level = StatRoot.Player[0].level;
        stats.experience = StatRoot.Player[0].experience;
        stats.expforlevel = StatRoot.Player[0].expforlevel;
    }

    private void Awake()
    {
        Init();
        //Подписки на события
        GlobalEventManager.OnPlayerDamage.AddListener(stats.ReceiveDamage);
        GlobalEventManager.OnConsumeExp.AddListener(stats.ReceiveExp);
        GlobalEventManager.OnConsumeFood.AddListener(stats.ReceiveHeal);
        GlobalEventManager.OnConsumeCoin.AddListener(stats.ReceiveMoney);


    }




    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        StartCoroutine(SpawnEnemy(spawnEnemyInterwal));
        StartCoroutine(SpawnFood(spawnFoodInterwal));
        StartCoroutine(SpawnCoin(spawnCoinInterwal));


        

    }
    private IEnumerator SpawnEnemy(float interwal)
    {

        yield return new WaitForSeconds(interwal);
        int tier =random.Next(0, 2);
        objectpool.SpawnFromPool(((Enemies)tier).ToString(), 
            new Vector3(random.Next(-40, 40)/2, random.Next(-40, 40) / 2, 0), 
            transform.rotation);
        StartCoroutine(SpawnEnemy(interwal));
    }

    private IEnumerator SpawnFood(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        objectpool.SpawnFromPool("Food", 
            new Vector3(random.Next(-40, 40) / 2, random.Next(-40, 40) / 2, 0), 
            transform.rotation);
        StartCoroutine(SpawnFood(interwal));
    }

    private IEnumerator SpawnCoin(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        objectpool.SpawnFromPool("Coin",
            new Vector3(random.Next(-40, 40), random.Next(-40, 40), 0),
            transform.rotation);
        StartCoroutine(SpawnCoin(interwal));
    }


    // Update is called once per frame
    void Update()
    {
        MyInterface();
        if (Input.GetKeyDown(KeyCode.Space))
            GamePause();

        if (Input.GetKeyDown(KeyCode.Escape))
            GameExit();


        if (Input.GetKeyDown(KeyCode.X))
            stats.LevelUp();
    }

    private void GameExit()
    {
        Application.Quit();
    }

    private void MyInterface()
    {
        hp.text = Math.Round(stats.maxhp) + "/" + Math.Round(stats.currentHP);
        Exp.text = Math.Round(stats.expforlevel) + "/" + Math.Round(stats.experience);
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();
    }
    void GamePause() {
            if (gameIsPaused)
            {
                gameIsPaused = !gameIsPaused;
                Time.timeScale = 1f;
         }
            else
            {
                gameIsPaused = !gameIsPaused;
                Time.timeScale = 0f;
        }
        }

}

