using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private ObjectPool objectpool;
    public PlayerStats stats;
    public GameObject Weapon;
    List<GameObject> Enemies = new List<GameObject>();
    float cooldown = 2f;
     


    Vector3 direct;

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
    private void Awake()
    {

        objectpool = ObjectPool.Instance;
        Weapon.GetComponent<CircleCollider2D>().radius = 50;
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKill);
    }

    private void EnemyKill(GameObject enemy)
    {
        Enemies.Remove(enemy);
    }

    // Start is called before the first frame update
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;
        if (cooldown <= 0 & Enemies.Count>0)
        {
            direct = FindEnemy();
            if (direct.z < 1)
            {
                GameObject fire = objectpool.SpawnFromPool("Fire", transform.position, transform.rotation);
                fire.GetComponent<MoveToEnemy>().direct = direct;
                cooldown = 2f;
            }
        }

    }

    public Vector3 FindEnemy()
    {
       Vector3 number = new Vector3(0, 0, 0);
        float min = 50f;
        foreach (var item in Enemies)
        {
            if (item.activeInHierarchy) { 
                float distance = (transform.position - item.transform.position).sqrMagnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform.position;

                }
            }
        }
        if (number.z != 100)
            return Vector3.Normalize(number - transform.position);
        else return new Vector3(0, 0, 100);

    }
}
