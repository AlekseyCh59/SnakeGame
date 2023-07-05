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


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
    }


    private void Start()
    {

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
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

                Instantiate(exp, transform.position, Quaternion.identity);
                Destroy(this.gameObject);

            }
        }
    }
    private void FixedUpdate()
    {
        if (this.gameObject) { 
        Direct = PlayerPos.position - transform.position;
        Direct.Normalize();
        rbEnemy.MovePosition(transform.position + Direct * gameManager.enemyStats.Speed * Time.deltaTime);
        }
    }
}
