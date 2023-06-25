using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Food": Destroy(collision.gameObject);
                //Player.Healing(); Научить работаь с функцией
                    break;            
            case "Coin": Destroy(collision.gameObject);
                //Player.ReceiveCoin(); Научить работаь с функцией
                break;            
            case "Exp": Destroy(collision.gameObject);
                Debug.Log("HHH");
                //Player.ReceiveExp(); Научить работаь с функцией
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
