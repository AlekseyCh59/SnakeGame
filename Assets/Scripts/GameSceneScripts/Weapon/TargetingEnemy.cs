using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MoveToEnemy : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]float Speed;
    float timeLife = 2;
    ObjectPool objectpool;
    public Vector2 direct = new();
    int ricochet = 1;
    Ricochet rico;

    private void Awake()
    {
        rico = GetComponent<Ricochet>();
    }


    private void OnEnable()
    {
        if (enemy != null) 
        {
           direct = (enemy.transform.position - transform.position).normalized;
        }
        ricochet = 1;
        timeLife = 2;  
        
    }
  
    private void Start()
    {
        objectpool = ObjectPool.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            if (ricochet>0)
            {
                ricochet -= 1;
                enemy = rico.GetNewTarget(10f, collision);
                if (enemy != collision.gameObject)
                direct = (enemy.transform.position - transform.position).normalized;
                else
                    objectpool.BackToPoll(this.gameObject);
            }
            else
            {
                enemy = null;
                objectpool.BackToPoll(this.gameObject);
            }
            

    }
    private void Update()
    {
        transform.Translate(Speed * direct * Time.deltaTime);
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            enemy = null;
            objectpool.BackToPoll(this.gameObject);
        }


    }
}
