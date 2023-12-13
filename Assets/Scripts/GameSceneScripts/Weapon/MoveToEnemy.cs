using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MoveToEnemy : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]float Speed;
    float timeLife = 2;
    ObjectPool objectpool;
    public Vector2 direct = new Vector2();
    bool ricochet = true;

    private void Awake()
    {

    }


    private void OnEnable()
    {
        if (enemy != null) 
        {
           direct = (enemy.transform.position - transform.position).normalized;

        }

        timeLife = 2;  
        
    }
  
    private void Start()
    {
        objectpool = ObjectPool.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            if (ricochet)
            {
                ricochet = false;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 10f);
                foreach (var item in collection)
                {

                }
            }else
            objectpool.BackToPoll(this.gameObject);

    }
    private void Update()
    {
        transform.Translate(Speed * direct * Time.deltaTime);
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            objectpool.BackToPoll(this.gameObject);
        }


    }
}
