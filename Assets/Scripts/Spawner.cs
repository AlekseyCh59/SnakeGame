using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnInterwal = 1f;   
    [SerializeField] private GameObject weapon;
    [SerializeField] private float weaponinterwal = 1f;


    [SerializeField] private GameObject snakeHead;
     GameScript gameScript;


   

    private void headSpawn()
    {
        Instantiate(snakeHead, new Vector3(0, 0, 0), Quaternion.identity);

    }

    private void tailSapwn()
    {

    }


    // корутина для спавна врагов
    private IEnumerator spawnEnemy(float interwal, GameObject enemy)
    {

        yield return new WaitForSeconds(interwal);
        enemy.name = Random.Range(0, 300).ToString();
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);//сделать безопасную зону игрока
        GetComponent<GameScript>().EnemyList.Add(newEnemy.transform);
        StartCoroutine(spawnEnemy(interwal, enemy));
    }

    //спавн выстрелов
    private IEnumerator weaponAttack(float interwal, GameObject weapon)
    {
        yield return new WaitForSeconds(interwal);
        if (gameScript.EnemyList.Count>0)
        {
            foreach (var item in gameScript.SnakeList)
            {
                GameObject attack = Instantiate(weapon, item.position, Quaternion.identity);
            }
           
        }
        StartCoroutine(weaponAttack(interwal, weapon));

    }
    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        headSpawn();

        StartCoroutine(weaponAttack(weaponinterwal, weapon));
        StartCoroutine(spawnEnemy(spawnInterwal, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
