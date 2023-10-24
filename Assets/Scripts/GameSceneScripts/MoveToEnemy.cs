using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
 

public class MoveToEnemy : MonoBehaviour
{
    public Vector3 direct =new Vector3();
    [SerializeField]float Speed;
    float timeLife = 2f;
    GameScript gameScript;
    ObjectPool objectpool;

    private void Awake()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
    }


    private void OnEnable()
    {
        timeLife = 2f;  
        
    }
  
    private void Start()
    {
        objectpool = ObjectPool.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            objectpool.BackToPoll(this.gameObject);

    }
    private void Update()
    {
        Debug.Log(direct);
        transform.Translate(Speed * direct * Time.deltaTime);
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            objectpool.BackToPoll(this.gameObject);
        }


    }
}
