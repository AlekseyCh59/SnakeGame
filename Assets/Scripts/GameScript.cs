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
    public enum Enemies
    {
        EnemyTier1,
        EnemyTier2,
        EnemyTier3,
        EnemyTier4
    }
    public enum Expiriens
    {
        ExpTier1,
        ExpTier2,
        ExpTier3,
        ExpTier4
    }

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
            objectpool.SpawnFromPool(ToExp(Enum.Parse<Enemies>(enemy.tag)).ToString(), enemy.transform.position, transform.rotation);
    }

    void SpawnEnemy()
    {
        int tier = Random.Range(0, 2);
        enemies++;
        objectpool.SpawnFromPool(((Enemies)tier).ToString(), new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
    }

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
    public static Expiriens ToExp(Enemies enemies) => enemies switch
    {
        Enemies.EnemyTier1 => Expiriens.ExpTier1,
        Enemies.EnemyTier2 => Expiriens.ExpTier2,
        Enemies.EnemyTier3 => Expiriens.ExpTier3,
        Enemies.EnemyTier4 => Expiriens.ExpTier4,
    };
}
