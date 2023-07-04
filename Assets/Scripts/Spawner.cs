using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnInterwal = 1f;


    [SerializeField] private GameObject snakeHead;
    GameScript gameScript;







    // корутина для спавна врагов
    private IEnumerator spawnEnemy(float interwal, GameObject enemy)
    {

        yield return new WaitForSeconds(interwal);
        enemy.name = Random.Range(0, 3).ToString();
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);//сделать безопасную зону игрока
        GetComponent<GameScript>().EnemyList.Add(newEnemy);
        StartCoroutine(spawnEnemy(interwal, enemy));
    }

    private void Awake()
    {
        Instantiate(snakeHead, new Vector3(0, 0, 0), Quaternion.identity);
    }


    // Start is called before the first frame update
    void Start()
    {


       gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();

        StartCoroutine(spawnEnemy(spawnInterwal, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
