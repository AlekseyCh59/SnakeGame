using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEat : MonoBehaviour
{
    public float food;
    private ObjectPool objectpool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            GlobalEventManager.SendConsumeFood(food);
            objectpool.BackToPoll(gameObject);
        }
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
}
