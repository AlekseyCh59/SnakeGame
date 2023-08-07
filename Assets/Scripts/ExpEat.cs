using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpEat : MonoBehaviour
{
    public float exp;
    private ObjectPool objectpool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            GlobalEventManager.SendConsumeExp(exp);
            objectpool.BackToPoll(gameObject);
        }
    }
    
    private void EnemyKilled(float exp)
    {
        this.exp = exp;
    }

    


    private void Awake()
    {
        objectpool = ObjectPool.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {

        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKilled);
    }

    private void OnDisable()
    {

        GlobalEventManager.OnEnemyKilled.RemoveListener(EnemyKilled);
    }
}
