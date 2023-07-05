using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
 

public class MoveToEmemy : MonoBehaviour
{
    Vector3 direct;
    [SerializeField]float Speed;
    float timeLife = 5f;
    GameScript gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();

    }
    private void Start()
    {
        float min = 9999;
        Transform number = gameManager.EnemyList[0];
        foreach (var item in gameManager.EnemyList)
        {
           float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - item.position.x),2) + Mathf.Pow((transform.position.y - item.position.y),2)); //расстояние между точками?

            if (distance < min)
            {
                name = item.name;
                min = distance;
                number = item;
            }
                
        }

        direct = number.position - transform.position;
            direct.Normalize();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Enemy"))
            Destroy(this.gameObject);

    }
    private void Update()
    {
        timeLife -= Time.deltaTime;
        if (timeLife<=0)
            Destroy(this.gameObject);
    }
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * direct);
    }
}
