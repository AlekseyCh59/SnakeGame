using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject snakeHead;


    void Start()
    {

        UniSpawn(snakeHead, new Vector2(0, 0));
        //StartCoroutine(weaponAttack(weaponinterwal, weapon));
        //StartCoroutine(spawnEnemy(spawnInterwal, enemy));
       // InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterwal);
        //InvokeRepeating(nameof(SpawnFire), 0, weaponinterwal);
    }


    private void headSpawn()
    {
        Instantiate(snakeHead, new Vector3(0, 0, 0), Quaternion.identity);


    }


    // корутина для спавна врагов
/*    void SpawnEnemy()
    {
        GameObject obj = ObjectPoolClass.current.GetPooledEnemy();
        if (obj == null) return;
        obj.transform.SetPositionAndRotation(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), transform.rotation);
        obj.name =Random.Range(0 , 100).ToString();
        obj.SetActive(true);

    }
     void SpawnFire()
    {
        foreach (var item in gameScript.EnemyList)
        {
            if (item.activeInHierarchy)
            {
                foreach (var item2 in gameScript.SnakeList)
                {
                    GameObject obj = ObjectPoolClass.current.GetPooledFire();
                    if (obj == null) return;
                    obj.transform.SetPositionAndRotation(item2.transform.position, transform.rotation);
                    obj.SetActive(true);
                }
                break;
            }
        }
             
    }*/

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

    public GameObject UniSpawn(GameObject gameObj, Vector2 whereSpawn)
    {
       return Instantiate(gameObj, whereSpawn, Quaternion.identity);
    }


    private void Awake()
    {

    }


}
