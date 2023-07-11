using UnityEngine;

public class Eating : Player
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Food":
                Destroy(collision.gameObject);
                {
                    Healing(10);// Научить работаь с функцией
                    break;
                }
            case "Coin":
                {
                    Destroy(collision.gameObject);
                    ReceiveCoin();
                    break;
                }
            case "Exp":
                {
                    ReceiveExp(1f);
                    Destroy(collision.gameObject);
                    
                    break;
                }

            case "Enemy":
                {
                    ReceiveDamageFromBump(collision.transform.GetComponent<EnemyScript>().gameScript.enemyStats.damage);
                    break;
                }
        }
    }
}
