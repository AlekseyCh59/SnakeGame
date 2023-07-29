using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public bool grow = false;
    }
    public Dictionary<string, List<GameObject>> AllpolledObjects = new Dictionary<string, List<GameObject>>(); //как то прикрутить надо
    public List<Pool> pools;

    public static ObjectPool Instance; 

    private void Start()
    {
        FillPool();

    }

    private void Awake()
    {
        Instance = this;
    }




    void FillPool()
    {
        foreach (Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i <= pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.position = new Vector3(999, 999, 0);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
            AllpolledObjects.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        foreach (var item in AllpolledObjects[tag])
        {
            if (!item.activeInHierarchy)
            {
                item.transform.SetPositionAndRotation(position, rotation);
                item.SetActive(true);
                return item;
            }
        }
        return null;

    }

    public void BackToPoll(GameObject obj)
    {
        obj.SetActive(false);
    }






}