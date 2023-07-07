using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    Rigidbody2D rbEnemy;
    Vector3 Direct;
    public float currentHp { get; private set; }
    public Transform exp;
    public GameScript gameManager; //PUBLIC?!
    Spawner spawner;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }


    private void Start()
    {

        currentHp = gameManager.enemyStats.maxhp;
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        gameManager.clearEnemy(this.transform);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("weapon"))
        {
            currentHp -= 2;
            if (currentHp <= 0)
            {

                spawner.UniSpawn(exp, this.transform.position);
                Destroy(this.gameObject);

            }
        }
    }
    private void FixedUpdate() //SOME SHIT HERE
    {
        float distance = 999;

        foreach (var item in gameManager.SnakeList)
        {
            if ((item.position - this.transform.position).magnitude < distance) { 
                distance = (item.position - this.transform.position).magnitude;
            PlayerPos = item;
        }
        }
        if (this.gameObject) { 
        Direct = PlayerPos.position - transform.position;
        Direct.Normalize();
        rbEnemy.MovePosition(transform.position + Direct * gameManager.enemyStats.Speed * Time.deltaTime);
        }
    }
}
