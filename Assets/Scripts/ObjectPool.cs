using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [Serializable]
    //основа для каждого пула объектов
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public bool grow = false;
    }
    public List<Pool> pools;    //создаем лист пулов через инспектор
    //словарь для хранения и удобного доступа к объектам
    public Dictionary<string, List<GameObject>> AllpolledObjects = new(); 


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FillPool();
    }

    //заполнение пулов объектами и помещение в словарь
    void FillPool()
    {
        foreach (Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i <= pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.name = pool.tag;
                obj.transform.position = new Vector3(999, 999, 0);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
            AllpolledObjects.Add(pool.tag, objectPool);
        }
    }

    //Вызов не активного объекта из пула и перемещение на заданные координаты
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

    //Деактивация объекта для повторного использования в дальнейшем
    public void BackToPoll(GameObject obj)
    {
        obj.SetActive(false);
    }
}