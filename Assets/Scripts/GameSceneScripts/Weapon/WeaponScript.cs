using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private ObjectPool objectpool;
    public GameObject Weapon;
    List<GameObject> Enemies = new List<GameObject>();
    float cooldown = 0.5f;
    GameObject enemy;
    Weapon weaponStat;
    float weaponRange = 50; //применить к колайдеру

    
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
    private void Awake()
    {

        objectpool = ObjectPool.Instance;
        Weapon.GetComponent<CircleCollider2D>().radius = weaponRange;
        GlobalEventManager.OnEnemyKilled+= EnemyKill;
        GlobalEventManager.OnEnemySpawned += EnemySpawn;
    }



    // Start is called before the first frame update
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && Enemies.Count>0)
        {
            enemy = FindEnemy();
            if (enemy!=null)
            {
                GameObject fire = objectpool.SpawnFromPool("Fire", transform.position, transform.rotation);
                fire.GetComponent<MoveToEnemy>().enemy = enemy;
                cooldown = 0.5f;
                fire.SetActive(true);
            }
        }

    }

    public GameObject FindEnemy()
    {
        GameObject obj = null;
        float min = float.MaxValue;
        foreach (var item in Enemies)
        {
            if (item.activeInHierarchy) { 
                float distance = (transform.position - item.transform.position).sqrMagnitude; 
                if (distance < min)
                {
                    min = distance;
                    obj = item;

                }
            }
        }
        if (min != float.MaxValue)
            return obj;
        else return null;

    }
}
