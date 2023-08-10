using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEat : MonoBehaviour
{
    public int coin;
    private ObjectPool objectpool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            //отправка сообщения для вызова события
            GlobalEventManager.SendConsumeCoin(coin);
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
