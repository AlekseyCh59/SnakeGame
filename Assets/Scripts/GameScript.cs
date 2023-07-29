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





    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        InvokeRepeating(nameof(SpawnEnemy), 1, 0.5f);
        InvokeRepeating(nameof(SpawnFire), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        MyInterface();

    }



    public void ClearEnemy(GameObject enemy)
    {
        SpawnExp(enemy);
        enemy.SetActive(false);

    }


    private void MyInterface()
    {

        hp.text = Math.Round(stats.maxhp) + "/" + Math.Round(stats.currentHP);
        Exp.text = Math.Round(stats.expForLevel) + "/" + Math.Round(stats.experiens);
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();
    }

    private void Awake()
    {

        stats.level = 1;
        stats.experiens = 0;
        stats.currentHP = stats.maxhp;

    }




    void SpawnEnemy()
    {
            objectpool.SpawnFromPool("EnemyTier1", new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
    }
    void SpawnExp(GameObject enemy)
    {
        objectpool.SpawnFromPool("ExpTier1", enemy.transform.position, transform.rotation);
    }
    void SpawnFire()
    {  
        foreach (var item in SnakeList)
        {
            objectpool.SpawnFromPool("FireType1", item.transform.position, item.transform.rotation);
        }
    }
}
