using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public PlayerStats stats;
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Food": Destroy(collision.gameObject);
                {
                    player.Healing(10);// ������� ������� � ��������
                    break;
                }       
            case "Coin": Destroy(collision.gameObject);
                //Player.ReceiveCoin(); ������� ������� � ��������
                break;            
            case "Exp": Destroy(collision.gameObject);
                //Player.ReceiveExp(); ������� ������� � ��������
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
