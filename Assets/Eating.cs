using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : Player
{
   // public PlayerStats stats;
    //public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Food": Destroy(collision.gameObject);
                {
                    Healing(10);// Научить работаь с функцией
                    break;
                }       
            case "Coin": Destroy(collision.gameObject);
                ReceiveCoin();
                break;            
            case "Exp": Destroy(collision.gameObject);
                ReceiveExp(1f,1f);
                break;
        }

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
