using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{

    // Интерфейс
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;

    // Скриптаблы
    public PlayerStats stats;
    // public EnemyStats enemyStats;

    //Массивы

    [SerializeField] public List<GameObject> SnakeList = new();
    ObjectPool objectpool;


    int enemies;


    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        InvokeRepeating(nameof(SpawnEnemy), 2, 0.5f);
        InvokeRepeating(nameof(SpawnFire), 1, 1);
        enemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MyInterface();
    }


/*
    public void ClearEnemy(GameObject enemy)
    {

        SpawnExp(enemy);
        enemy.SetActive(false);

    }*/


    private void MyInterface()
    {

        hp.text = Math.Round(stats.maxhp) + "/" + Math.Round(stats.currentHP);
        Exp.text = Math.Round(stats.expForLevel) + "/" + Math.Round(stats.experiens);
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();
    }

    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKill);
        stats.level = 1;
        stats.experiens = 0;
        stats.currentHP = stats.maxhp;

    }

    private void EnemyKill(GameObject enemy)
    {
        enemies--;
        string tag = null;
        switch (enemy.tag)
        {
            case "EnemyTier1": tag = "ExpTier1"; break;
            case "EnemyTier2": tag = "ExpTier2"; break;
            case "EnemyTier3": tag = "ExpTier3"; break;
            case "EnemyTier4": tag = "ExpTier4"; break;
        }
        if (tag != null)
        {
            objectpool.SpawnFromPool(tag, enemy.transform.position, transform.rotation);
        }
        else { Debug.Log("Enemy tag = null - GameScript SpawnEnemy"); }

    }

    void SpawnEnemy()
    {
        enemies++;
        string str = "";
        int tier = Random.Range(1, 3);
        switch (tier)
        {
            case 1:str = "EnemyTier1";break;
            case 2:str = "EnemyTier2";break;
        }
        objectpool.SpawnFromPool(str, new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
    }
/*    void SpawnExp(GameObject enemy)
    {
        string tag=null;
        switch (enemy.tag)
        { 
            case "EnemyTier1": tag = enemy.tag;break;
            case "EnemyTier2": tag = enemy.tag;break;
            case "EnemyTier3": tag = enemy.tag;break;
            case "EnemyTier4": tag = enemy.tag;break;
        }
        if (tag != null)
        {
            objectpool.SpawnFromPool(tag, enemy.transform.position, transform.rotation);
        }
        else { Debug.Log("Enemy tag = null - GameScript SpawnEnemy"); }
        
    }*/
    void SpawnFire()
    {
        if (enemies > 0)
        {
            foreach (var item in SnakeList)
            {
                objectpool.SpawnFromPool("FireType1", item.transform.position, item.transform.rotation);
            }
        }
    }
}
