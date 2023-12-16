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
    public RectTransform Fluid;
    public float fluidPos;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;
    
    // Скриптаблы
    PlayerManager playerStats;
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




    private void Awake()
    {
        playerStats = this.GetComponent<PlayerManager>();
    }




    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        StartCoroutine(SpawnFood(spawnFoodInterwal));
        StartCoroutine(SpawnCoin(spawnCoinInterwal));

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
        objectpool.SpawnFromPool("Coin", new Vector3(random.Next(-40, 40)/2, random.Next(-40, 40)/2, 0),
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
            playerStats.LevelUp();

        spawnEnemyInterwal -= Time.deltaTime;
        if (spawnEnemyInterwal <= 0)
        {
            spawnEnemyInterwal = 1;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {   
        GameObject obj = objectpool.SpawnFromPool(((Enemies)random.Next(0, 2)).ToString(),
        new Vector3(random.Next(-40, 40) / 2, random.Next(-40, 40) / 2, 0), transform.rotation);
        GlobalEventManager.SendEnemySpawn(obj);
        obj.name = random.Next(0,100).ToString();
        obj.SetActive(true);
    }

    private void GameExit()
    {
        Application.Quit();
    }

    private void MyInterface()
    {
        hp.text = (int)playerStats.maxhp + "/" + (int)playerStats.currentHP;
        fluidPos = -92f + (84.5f * (int)(playerStats.currentHP / playerStats.maxhp));
        Fluid.localPosition = new Vector3(0, fluidPos, 0);
        Exp.text = (int)playerStats.expforlevel + "/" + (int)playerStats.experience;
        money.text = playerStats.money.ToString();
        level.text = playerStats.level.ToString();
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

