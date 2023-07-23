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
    public Dictionary<string, Queue<GameObject>> AllpolledObjects = new Dictionary<string, Queue<GameObject>>(); //как то прикрутить надо
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
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            AllpolledObjects.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (AllpolledObjects[tag].Count>0)
        {
            GameObject obj = AllpolledObjects[tag].Dequeue();

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);
            //AllpolledObjects[tag].Enqueue(obj);
            return obj;
        }
        return null;

    }

    public void BackToPoll(string tag, GameObject obj)
    {
        obj.SetActive(false);
        AllpolledObjects[tag].Enqueue(obj);
    }






}