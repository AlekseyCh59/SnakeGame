using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    Rigidbody2D rbEnemy;
    Vector3 Direct;
    public EnemyStats stats;
    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.tag == "Player")
        {

        }
    }
    private void FixedUpdate()
    {
        Direct = PlayerPos.position - transform.position;
        Direct.Normalize();
        rbEnemy.MovePosition(transform.position + Direct * stats.Speed * Time.deltaTime);
    }
}
