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
        float min = (transform.position - gameManager.EnemyList[0].transform.position).magnitude;

        Transform number = gameManager.EnemyList[0].transform;
        foreach (var item in gameManager.EnemyList)
        {
            float distance = (transform.position - gameManager.EnemyList[0].transform.position).magnitude; //расстояние между точками?
            if (item.activeInHierarchy)
            {
            if (distance < min)
            {
                name = item.name;
                min = distance;
                number = item.transform;
            }
            }
        }

        direct = number.position - transform.position;
            direct.Normalize();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
            this.gameObject.SetActive(false);

    }
    private void Update()
    {
        timeLife -= Time.deltaTime;
        if (timeLife<=0)
            this.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * direct);
    }
}
