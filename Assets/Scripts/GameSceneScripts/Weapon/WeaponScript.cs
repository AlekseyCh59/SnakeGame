using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private ObjectPool objectpool;
    public GameObject Weapon;
    private List<GameObject> Enemies = new List<GameObject>();
    float cooldown = 2f;
    GameObject enemy;
    public Weapon weaponStat;
    float weaponRange = 50; //ÔËÏÂÌËÚ¸ Í ÍÓÎ‡È‰ÂÛ
    LineRenderer line;

    string bullet = "Fire";
    //string bullet = "Lighting";
    Vector2 spawnPoint;
    bool nontarget = false;
    bool instancedamage = true;
    int target=0;
    System.Random random = new System.Random();

    List<GameObject> tier1 = new();
    List<GameObject> tier2 = new();
    List<GameObject> tier3 = new();
    List<GameObject> tier4 = new();
    List<GameObject> tier5 = new();

    enum Targeting { 
        Nearest,
        Furthest,
        Weakest,
        Strogest,
        Random,
        Point
    }

    #region CollectTargets
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Contains("Enemy"))
            {
                Enemies.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.Contains("Enemy"))
            {
                Enemies.Remove(collision.gameObject);
            }
        }

        private void EnemyKill(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }
        private void EnemySpawn(GameObject enemy)
        {
            if (enemy.activeInHierarchy)
            {
                float distance = (transform.position - enemy.transform.position).sqrMagnitude;
                if (distance < weaponRange)
                    Enemies.Add(enemy);
            }
        }
    #endregion
   
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.useWorldSpace = true;
        line.endWidth = 0.2f;
        line.startWidth = 0.2f;
        line.startColor = Color.red;
        line.endColor = Color.red;
        if (target !=6)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            GlobalEventManager.OnEnemyKilled += EnemyKill;
            GlobalEventManager.OnEnemySpawned += EnemySpawn;
        }
        objectpool = ObjectPool.Instance;
        //Weapon.GetComponent<CircleCollider2D>().radius = weaponStat.distance;

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && Enemies.Count>0)
        {
            spawnPoint = gameObject.transform.position;
            FindTarget();
            Fire(bullet, spawnPoint); //œ≈–≈ƒ¿¬¿“‹ œ¿–¿Ã≈“–€ »« ¡ƒ 1.◊“Œ —œ¿¬Õ»Ã 2. ”ƒ¿ —œ¿¬Õ»Ã
        }
    }

    //œËˆÂÎ˚
    public void FindTarget()
    {
        switch ((Targeting)target)
        {
            case Targeting.Nearest:
                {
                    enemy = Nearest(float.MaxValue, Enemies);
                    break;
                }

            case Targeting.Furthest:
                {
                    Furthest(0, Enemies);
                    break;
                }

            case Targeting.Weakest:
                {
                    Weakest(Enemies);
                    break;
                }

            case Targeting.Strogest:
                {
                    Strongest(Enemies);
                    break; }
                
            case Targeting.Random:
                {
                    enemy = Enemies[random.Next(Enemies.Count)];
                    spawnPoint = enemy.transform.position;
                    break;
                }
            case Targeting.Point:
                {
                    spawnPoint = new Vector2(random.Next((int)transform.position.x, (int)transform.position.x + (int)weaponRange),
                                              random.Next((int)transform.position.y, (int)transform.position.y + (int)weaponRange));
                    break;
                }
            default:
                break;
        }
    }


    private GameObject Nearest(float min, List<GameObject>Enemies)
    {
        GameObject obj = null;
        foreach (var item in Enemies)
        {
                float distance = (transform.position - item.transform.position).sqrMagnitude;
                if (distance < min)
                {
                    min = distance;
                    obj = item;
                }
        }
        if (min != float.MaxValue)
            return obj;
        else
            return null;
    }
    private GameObject Furthest(float max, List<GameObject> Enemies)
    {
        GameObject obj = null;
        foreach (var item in Enemies)
        {
            float distance = (transform.position - item.transform.position).sqrMagnitude;
            if (distance > max)
            {
                max = distance;
                obj = item;
            }
        } 
        if (max != float.MinValue)
            return obj;
        else
            return null;
    }  
    private void Weakest(List<GameObject> Enemies)
    {
        foreach (var item in Enemies)
        {
            if (item.name == "EnemyTier1")
                tier1.Add(item);
            else if (item.name == "EnemyTier2")
                tier2.Add(item);
            else if (item.name == "EnemyTier3")
                tier3.Add(item);
            else if (item.name == "EnemyTier4")
                tier4.Add(item);
            else
                tier5.Add(item);
        }
        if (tier1.Count > 0)
            Nearest(float.MaxValue, tier1);
        else if (tier2.Count > 0)
            Nearest(float.MaxValue, tier2);
        else if (tier3.Count > 0)
            Nearest(float.MaxValue, tier3);
        else if (tier4.Count > 0)
            Nearest(float.MaxValue, tier4);
        else Nearest(float.MaxValue, tier5);

    }
    private void Strongest(List<GameObject> Enemies)
    {
        foreach (var item in Enemies)
        {
            if (item.name == "EnemyTier1")
                tier1.Add(item);
            else if (item.name == "EnemyTier2")
                tier2.Add(item);
            else if (item.name == "EnemyTier3")
                tier3.Add(item);
            else if (item.name == "EnemyTier4")
                tier4.Add(item);
            else
                tier5.Add(item);
        }
        if (tier5.Count > 0)
            Nearest(float.MaxValue, tier5);
        else if (tier4.Count > 0)
            Nearest(float.MaxValue, tier4);
        else if (tier3.Count > 0)
            Nearest(float.MaxValue, tier3);
        else if (tier2.Count > 0)
            Nearest(float.MaxValue, tier2);
        else Nearest(float.MaxValue, tier1);

    }



    public void Fire(string prefab, Vector2 tranform)
    {
            line.positionCount = 0;
            GameObject fire = objectpool.SpawnFromPool(prefab, tranform, transform.rotation);
            fire.GetComponent<BulletStats>().GetStats(10,20,15,10, enemy);
            fire.GetComponent<BulletStats>().line = line;
            enemy = null;
            cooldown = 2f;
            fire.SetActive(true);
    }
}
