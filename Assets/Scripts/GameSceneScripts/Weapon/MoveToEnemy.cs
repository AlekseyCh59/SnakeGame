using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MoveToEnemy : MonoBehaviour
{
    [SerializeField]float Speed;
    float timeLife = 2;
    ObjectPool objectpool;
    private BulletStats stats;
    public Vector2 direct = new();




    private void OnEnable()
    {
        objectpool = ObjectPool.Instance;
        stats = GetComponent<BulletStats>();
        if (stats.enemy != null) 
        {
           direct = (stats.enemy.transform.position - transform.position).normalized;
        }
        timeLife = 2;  
        
    }
  
    private void Awake()
    {

    }

    private void Update()
    {
        transform.Translate(Speed * direct * Time.deltaTime);
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            stats.enemy = null;
            objectpool.BackToPoll(this.gameObject);
        }


    }
}
