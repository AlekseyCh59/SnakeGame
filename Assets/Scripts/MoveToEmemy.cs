using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
 

public class MoveToEmemy : MonoBehaviour
{
    Vector3 direct;
    [SerializeField]float Speed;
    float timeLife = 2f;
    GameScript gameScript;

    private void Awake()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();

    }


    private void OnEnable()
    {
        timeLife = 2f;
        float min = (transform.position - gameScript.EnemyList[0].transform.position).magnitude;
        Transform number = gameScript.EnemyList[0].transform;
        foreach (var item in gameScript.EnemyList)
        {
            if (item.activeInHierarchy)
            {
                float distance = (transform.position - item.transform.position).magnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform;
                }
            }
        }

        direct = number.position - transform.position;
        direct.Normalize();
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            this.gameObject.SetActive(false);

    }
    private void Update()
    {
        timeLife -= Time.deltaTime;
        if (timeLife <= 0) {
            this.gameObject.SetActive(false);
        }
            
    }
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * direct);
    }
}
