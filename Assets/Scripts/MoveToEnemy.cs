using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
 

public class MoveToEnemy : MonoBehaviour
{
    Vector3 direct;
    [SerializeField]float Speed;
    float timeLife = 2f;
    GameScript gameScript;
    ObjectPool objectpool;

    private void Awake()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();

    }


    private void OnEnable()
    {
        timeLife = 2f;
        float min = 999;
        Vector3 number = new Vector3(0,0,0);
        foreach (var item in objectpool.AllpolledObjects["EnemyTier1"])
        {
            if (item.activeInHierarchy)
            {
                float distance = (transform.position - item.transform.position).magnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform.position;
                }
            }
        }      
        foreach (var item in objectpool.AllpolledObjects["EnemyTier2"])
        {
            if (item.activeInHierarchy)
            {
                float distance = (transform.position - item.transform.position).magnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform.position;
                }
            }
        }
        direct = number - transform.position;
        direct.Normalize();



    }
    private void Start()
    {
        objectpool = ObjectPool.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            this.gameObject.SetActive(false);

    }
    private void Update()
    {
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            this.gameObject.SetActive(false);
        }
            
    }
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * direct);
    }
}
