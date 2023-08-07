using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;



public class GameScript : MonoBehaviour
{

    // ���������
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;

    // ����������
    public PlayerStats stats;
    // public EnemyStats enemyStats;

    //�������

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
    public enum Consumables
    {
        ExpTier1,
        ExpTier2,
        ExpTier3,
        ExpTier4,
        Coin,
        Food
    }

    private void Awake()
    {

        //GlobalEventManager.OnEnemyKilled.AddListener(EnemyKill);
        // GlobalEventManager.OnConsumeExp.AddListener(Consume);
        /*        stats.level = 1;
                stats.experiens = 0;
                stats.currentHP = stats.maxhp;*/

    }


    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        InvokeRepeating(nameof(SpawnEnemy), 2, 0.5f);
        InvokeRepeating(nameof(SpawnFire), 1, 1);
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

    //�� ������������ � ���� ��
    private void EnemyKill(GameObject enemy)
    {
           objectpool.SpawnFromPool(ToExp(Enum.Parse<Enemies>(enemy.name)).ToString(), enemy.transform.position, transform.rotation);
    }

    void SpawnEnemy()
    {
        int tier = Random.Range(0, 2);
        objectpool.SpawnFromPool(((Enemies)tier).ToString(), new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), transform.rotation);
    }

    void SpawnFire()
    {
        if (enemies > 0)
        {
            for (int i = 1; i < SnakeList.Count; i++)
            {
                objectpool.SpawnFromPool("FireType1", SnakeList[i].transform.position, SnakeList[i].transform.rotation);
            }

        }
    }
    public static Consumables ToExp(Enemies enemies) => enemies switch
    {
        Enemies.EnemyTier1 => Consumables.ExpTier1,
        Enemies.EnemyTier2 => Consumables.ExpTier2,
        Enemies.EnemyTier3 => Consumables.ExpTier3,
        Enemies.EnemyTier4 => Consumables.ExpTier4,
    };
    public static int ExpToPlayer(Consumables consumable) => consumable switch //???
    {
        Consumables.ExpTier1 => 2,
        Consumables.ExpTier2 => 10,
        Consumables.ExpTier3 => 50,
        Consumables.ExpTier4 => 100,
    };
}
