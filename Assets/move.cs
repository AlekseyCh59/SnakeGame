using TMPro;
using UnityEngine;

public class move : MonoBehaviour
{
    float currentSpeed;
    private Player playerChar;
    Vector3 mover = new Vector3(0, 0, 0);
    string key;
    private void Start()
    {
        playerChar = GetComponent<Player>();
            }


    private void FixedUpdate()
    {



        if (Input.GetAxis("Vertical") > 0.1 & key != "down")
        {
            key = "up";
            Control(key);
        }
        else if (Input.GetAxis("Vertical") < -0.1 &key !="up")
        { key = "down";
            Control(key);
        }
          
        if (Input.GetAxis("Horizontal") > 0.1& key!="left")
        {
            key = "right";
            Control(key);
        }

        else if (Input.GetAxis("Horizontal") < -0.1& key!="right")
        {
            key = "left";
            Control(key);
        }



        transform.Translate(mover);
    }

    private void Control(string key)
    {
        currentSpeed = playerChar.speed * Time.deltaTime;
   
        
        switch (key)
        {
            case "up": mover= new Vector3(0, currentSpeed, 0); break;
            case "down": mover = new Vector3(0, -currentSpeed, 0); break;
            case "right": mover = new Vector3(currentSpeed, 0, 0); break;
            case "left": mover = new Vector3(-currentSpeed, 0, 0); break;

        }
        
        

    }

}