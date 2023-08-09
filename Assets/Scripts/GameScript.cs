using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement; 



public class GameScript : MonoBehaviour
{
    // Интерфейс
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;

    // Скриптаблы
    public PlayerStats stats;


    int enemies;
    public static bool gameIsPaused = false;

    //Массивы

    [SerializeField] public List<GameObject> SnakeList = new();
    ObjectPool objectpool;
    private float spawnEnemyInterwal = 1;
    private float spawnFireInterwal = 1.5f;
    private float spawnFoodInterwal = 10;

    public enum Enemies
    {
        EnemyTier1,
        EnemyTier2,
        EnemyTier3,
        EnemyTier4
    }

    private void Awake()
    {
        GlobalEventManager.OnPlayerDamage.AddListener(stats.ReceiveDamage);
        GlobalEventManager.OnConsumeExp.AddListener(stats.ReceiveExp);
        GlobalEventManager.OnConsumeFood.AddListener(stats.ReceiveHeal);
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKill);
    }

    private void EnemyKill(float arg0)
    {
        enemies--;
    }


    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        StartCoroutine(SpawnEnemy(spawnEnemyInterwal));
        StartCoroutine(SpawnFire(spawnFireInterwal));
        StartCoroutine(SpawnFood(spawnFoodInterwal));

    }
    private IEnumerator SpawnEnemy(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        int tier = Random.Range(0, 2);
        objectpool.SpawnFromPool(((Enemies)tier).ToString(), new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
        enemies++;
        StartCoroutine(SpawnEnemy(interwal));
    }

    private IEnumerator SpawnFood(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        objectpool.SpawnFromPool("Food", new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
        enemies++;
        StartCoroutine(SpawnFood(interwal));
    }

    private IEnumerator SpawnFire(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        if (enemies > 0)
        {
            for (int i = 1; i < SnakeList.Count; i++)
            {
                objectpool.SpawnFromPool("Fire", SnakeList[i].transform.position, SnakeList[i].transform.rotation);
            }
        }
        StartCoroutine(SpawnFire(interwal));
    }



    // Update is called once per frame
    void Update()
    {
        MyInterface();
        if (Input.GetKeyDown(KeyCode.Space))
            GamePause();

        if (Input.GetKeyDown(KeyCode.Escape))
            GameExit();
        }

    private void GameExit()
    {
        Application.Quit();
    }

    private void MyInterface()
    {

        hp.text = Math.Round(stats.maxhp) + "/" + Math.Round(stats.currentHP);
        Exp.text = Math.Round(stats.expForLevel) + "/" + Math.Round(stats.experiens);
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

