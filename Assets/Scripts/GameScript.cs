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
    public EnemyStats enemyStats;
    public static List<float> expiriens = new() { 1, 4, 8, 10, 20, 100 };

    //Массивы
    [SerializeField] public List<GameObject> EnemyList = new();
    [SerializeField] public List<GameObject> FireList = new();
    [SerializeField] public List<GameObject> ExpList = new();
    [SerializeField] public List<GameObject> SnakeList = new();

    [SerializeField] private GameObject fire;
    [SerializeField] private int amountFire = 10;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int amountEnemy = 10;
    [SerializeField] private GameObject tail;
    [SerializeField] private int amountTail = 0;
    [SerializeField] private GameObject exp;
    [SerializeField] private int amountExp = 10;
    /*    [SerializeField] private float attackInterwal = 1f;*/
    public Dictionary<GameObject, List<GameObject>> AllpolledObjects = new Dictionary<GameObject, List<GameObject>>(); //как то прикрутить надо






    // Start is called before the first frame update
    void Start()
    {
        AllpolledObjects.Add(enemy, EnemyList);
        AllpolledObjects.Add(fire, FireList);

        // AllpolledObjects.Add(tail, TailList);
        AllpolledObjects.Add(exp, ExpList);
        PoolSome(enemy, amountEnemy);
        PoolSome(fire, amountFire);
        PoolSome(exp, amountExp);
        // PoolSome(tail, amountTail);
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

    private void PoolSome(GameObject poolingObj, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolingObj);
            obj.SetActive(false);
            AllpolledObjects[poolingObj].Add(obj);
        }

    }

    public GameObject GetPooledObj(string list)
    {
        if (list == "enemy")
        {
            foreach (var item in AllpolledObjects[enemy])
            {
                if (!item.activeInHierarchy)
                    return item;
            }

            if (true)
            {
                GameObject obj = (GameObject)Instantiate(enemy);
                EnemyList.Add(obj);
                return obj;
            }
        }

        if (list == "fire")
        {
            foreach (var item in FireList)
            {
                if (!item.activeInHierarchy)
                    return item;
            }
            if (true)
            {
                GameObject obj = (GameObject)Instantiate(fire);
                FireList.Add(obj);
                return obj;
            }
        }

        if (list == "exp")
        {
            foreach (var item in ExpList)
            {
                if (!item.activeInHierarchy)
                    return item;
            }
            if (true)
            {
                GameObject obj = (GameObject)Instantiate(exp);
                ExpList.Add(obj);
                return obj;
            }
        }
        else
            return null;
    }


    void SpawnEnemy()
    {
        GameObject obj = GetPooledObj("enemy");
        if (obj == null) return;
        obj.transform.SetPositionAndRotation(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), transform.rotation);
        obj.SetActive(true);

    }
    void SpawnExp(GameObject enemy)
    {
        GameObject obj = GetPooledObj("exp");
        Debug.Log(obj);
        if (obj == null) return;
        obj.transform.SetPositionAndRotation(enemy.transform.position, enemy.transform.rotation);
        obj.SetActive(true);

    }
    void SpawnFire()
    {
        foreach (var item in SnakeList)
        {
            GameObject obj = GetPooledObj("fire");
            if (obj == null) return;
            obj.transform.SetPositionAndRotation(item.transform.position, item.transform.rotation);
            obj.SetActive(true);
        }
    }
}
