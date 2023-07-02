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
                    Destroy(collision.gameObject);
                    ReceiveExp(1f);
                    break;
                }

            case "Enemy":
                {
                    ReceiveDamageFromBump(1);
                    break;
                }
        }
    }
}
