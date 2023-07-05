using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class GameScript : MonoBehaviour
{   

    // Интерфейс
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;

    // Скриптаблы
    public PlayerStats stats;
    public EnemyStats enemyStats;
    public static List<float> expiriens = new() { 1,4,8,10,20,100};



    //Массивы
    [SerializeField] public List<Transform> EnemyList { get; private set; } = new();

    [SerializeField] public List<Transform> SnakeList = new();

    [SerializeField] private GameObject weapon;
    /*    [SerializeField] private float attackInterwal = 1f;*/




    public void clearEnemy(Transform enemy)
    {
        EnemyList.Remove(enemy);
    }


    private void MyInterface()
    {

        hp.text = Math.Round(stats.maxhp) + "/" + Math.Round(stats.currentHP);
        Exp.text = Math.Round(stats.expForLevel) + "/" + Math.Round(stats.experiens);
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();

                  
    }

    



    //нужно применить к списку хвоста и голове.
    /* private IEnumerator weaponAttack(float interwal, GameObject weapon)
     {
         yield return new WaitForSeconds(interwal);
         if (EnemyList.Count != 0)
         {
             GameObject attack = Instantiate(weapon, ???????, Quaternion.identity,);
             StartCoroutine(weaponAttack(interwal, weapon));
         }

     }*/
    private void Awake()
    {

        stats.level = 1;
        stats.experiens = 0;
        stats.currentHP = stats.maxhp;
        
    }




    // Start is called before the first frame update
    void Start()
    {

       // StartCoroutine(spawnEnemy(attackInterwal, weapon));
    }

    // Update is called once per frame
    void Update()
    {
        
        MyInterface();

    }


}
