using UnityEngine;

public class Eating : Player
{
    private ObjectPool objectpool;
    public GameScript gameScript; //PUBLIC?!

    private void Start()
    {
        objectpool = ObjectPool.Instance;
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "consumable":
                {
                    
                    GlobalEventManager.SendConsume(collision.gameObject.name);
                    objectpool.BackToPoll(collision.gameObject);                 
                    break;
                }

            case "Enemy":
                {
                    ReceiveDamageFromBump(collision.transform.GetComponent<EnemyScript>().enemyStats.damage);
                    break;
                }
        }
    }
}
