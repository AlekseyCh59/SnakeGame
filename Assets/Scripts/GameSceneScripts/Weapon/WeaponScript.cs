using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private ObjectPool objectpool;
    public GameObject Weapon;
    List<GameObject> Enemies = new List<GameObject>();
    float cooldown = 2f;
    GameObject enemy;
    public Weapon weaponStat;
    float weaponRange = 50; //ÔËÏÂÌËÚ¸ Í ÍÓÎ‡È‰ÂÛ


    string bullet = "Fire";
    Vector2 spawnPoint;
    bool nontarget = false;
    bool instancedamage = true;
    int target=0;
    System.Random random = new System.Random();



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
        GameObject obj = null;
        switch ((Targeting)target)
        {
            case Targeting.Nearest:
                {
                    float min = float.MaxValue;
                    foreach (var item in Enemies)
                    {
                        if (item.activeInHierarchy)
                        {
                            float distance = (transform.position - item.transform.position).sqrMagnitude;
                            if (distance < min)
                            {
                                min = distance;
                                obj = item;
                            }
                        }
                    }
                    if (min != float.MaxValue)
                    {
                        enemy = obj;
                    }
                    else
                        enemy = null;
                    break;
                }

            case Targeting.Furthest:
                {
                    float max = float.MinValue;
                    foreach (var item in Enemies)
                    {
                        if (item.activeInHierarchy)
                        {
                            float distance = (transform.position - item.transform.position).sqrMagnitude;
                            if (distance > max)
                            {
                                max = distance;
                                obj = item;
                            }
                        }
                    }
                    if (max != float.MinValue)
                        enemy = obj;
                    else
                        enemy = null;
                    break;
                }

            case Targeting.Weakest:
                {

                    break;
                }

            case Targeting.Strogest:
                break;
            case Targeting.Random:
                enemy = Enemies[random.Next(Enemies.Count)];
                spawnPoint = enemy.transform.position;
                break;
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

    public void Fire(string prefab, Vector2 tranform)
    {
            GameObject fire = objectpool.SpawnFromPool(prefab, tranform, transform.rotation);
            fire.GetComponent<MoveToEnemy>().enemy = enemy;
            enemy = null;
            cooldown = 2f;
            fire.SetActive(true);
    }
}
