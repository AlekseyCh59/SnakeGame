using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MoveToEmemy : MonoBehaviour
{
    [SerializeField] Transform Enemy;
    Vector3 Direct;
    [SerializeField]float Speed;
    float timeLife = 5f;
    private void Start()
    {
        Enemy = GameObject.FindWithTag("Enemy").transform;
        Direct = Enemy.position - transform.position;
        Direct.Normalize();
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
        transform.Translate(Direct*Speed*Time.deltaTime);
    }
}
