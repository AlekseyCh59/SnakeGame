using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpEat : MonoBehaviour
{
    int Exp;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {


        }
    }
    
    private void EnemyKilled(float exp)
    {

    }



    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKilled);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    }
