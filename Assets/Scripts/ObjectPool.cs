/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolClass: MonoBehaviour
{
    public static ObjectPoolClass current;
    public GameObject enemy;
    public GameObject fire;
    public int poolAmount = 10;
    public bool willGrow = true;
    public List<GameObject> fireList;
    GameScript gameScript;
    


    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        //pooledObjects = new List<GameObject>();
            }



    public GameObject GetPooledEnemy()
    {
        foreach (var item in gameScript.EnemyList)
        {
            if (!item.activeInHierarchy)
                return item;
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(enemy);
                //gameScript.EnemyList.Add(obj);
                return obj;
            }
        }
        return null;
    }

     public GameObject GetPooledFire()
    {
        foreach (var item in fireList)
        {
            if (!item.activeInHierarchy)
                return item;
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(fire);
                return obj;
            }
        }
        return null;
    }



}
*/