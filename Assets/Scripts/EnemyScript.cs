using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    Rigidbody2D rbEnemy;
    Vector3 Direct;
    public EnemyStats stats;
    float currentHp;
    public Transform exp;





    private void Start()
    {

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        currentHp = stats.maxhp;
        rbEnemy = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("weapon"))
        {
            currentHp -= 2;
            if (currentHp <= 0)
            {
                Instantiate(exp, transform.position, Quaternion.identity);
                Debug.Log(transform.position);
                Destroy(this.gameObject);
                
            }
        }
    }
    private void FixedUpdate()
    {
        if (this.gameObject) { 
        Direct = PlayerPos.position - transform.position;
        Direct.Normalize();
        rbEnemy.MovePosition(transform.position + Direct * stats.Speed * Time.deltaTime);
        }
    }
}
