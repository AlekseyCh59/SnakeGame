using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnInterwal = 1f;   
    [SerializeField] private GameObject weapon;
    [SerializeField] private float weaponinterwal = 10f;
    int enemyCount = 100;

    [SerializeField] private GameObject snakeHead;
     GameScript gameScript;

    void Start()
    {

        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        UniSpawn(snakeHead.transform, new Vector2(0, 0));
        //StartCoroutine(weaponAttack(weaponinterwal, weapon));
        //StartCoroutine(spawnEnemy(spawnInterwal, enemy));
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterwal);
        InvokeRepeating(nameof(SpawnFire), 0, weaponinterwal);
    }




    private void headSpawn()
    {
        Instantiate(snakeHead, new Vector3(0, 0, 0), Quaternion.identity);


    }


    // корутина для спавна врагов
    void SpawnEnemy()
    {
        GameObject obj = ObjectPoolClass.current.GetPooledEnemy();
        if (obj == null) return;
        obj.transform.SetPositionAndRotation(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), transform.rotation);
        obj.SetActive(true);

    }
     void SpawnFire()
    {
             foreach (var item in gameScript.SnakeList)
            {
            GameObject obj = ObjectPoolClass.current.GetPooledFire();
            if (obj == null) return;
                obj.transform.SetPositionAndRotation(item.position, transform.rotation);
                obj.SetActive(true);
            }
    }

/*    private IEnumerator spawnEnemy(float interwal, GameObject enemy)
    {

        yield return new WaitForSeconds(interwal);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);//сделать безопасную зону игрока
        GetComponent<GameScript>().EnemyList.Add(newEnemy);
        StartCoroutine(spawnEnemy(interwal, enemy));
    }*/


    //спавн выстрелов
/*    private IEnumerator weaponAttack(float interwal, GameObject weapon)
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
    }*/

    public Transform UniSpawn(Transform gameObj, Vector2 whereSpawn)
    {
       return Instantiate(gameObj, whereSpawn, Quaternion.identity);
    }


    private void Awake()
    {

    }


}
