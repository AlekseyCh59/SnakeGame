using UnityEngine;
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
    Dictionary<GameObject, GameObject> AllpolledObjects = new Dictionary<GameObject, GameObject>(); //как то прикрутить надо

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        //pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            GameObject obj2 = (GameObject)Instantiate(fire);
            obj.SetActive(false);
            obj2.SetActive(false);
            gameScript.EnemyList.Add(obj);
            fireList.Add(obj2);

        }
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
