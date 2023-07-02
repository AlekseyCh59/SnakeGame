using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;
    public PlayerStats stats;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnInterwal = 1f;
    [SerializeField] private List<GameObject> EnemyList = new();

    [SerializeField] private GameObject weapon;
    [SerializeField] private float attackInterwal = 1f;




    private void MyInterface()
    {
        hp.text = stats.maxhp + "/" + stats.currentHP;
        Exp.text = stats.expForLevel.ToString() + "/" + stats.experiens.ToString();
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();
    }
    // корутина для спавна врагов
    private IEnumerator spawnEnemy(float interwal, GameObject enemy)
    {
        yield return new WaitForSeconds(interwal);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);//сделать безопасную зону игрока
        EnemyList.Add(newEnemy);
        StartCoroutine(spawnEnemy(interwal, enemy));
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





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterwal, enemy));
       // StartCoroutine(spawnEnemy(attackInterwal, weapon));
    }

    // Update is called once per frame
    void Update()
    {
        MyInterface();

    }


}
