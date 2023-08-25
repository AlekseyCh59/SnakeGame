using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private ObjectPool objectpool;



    private void Awake()
    {
        objectpool = ObjectPool.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 FindEnemy()
    {
        float min = 999;
        Vector3 number = new Vector3(0, 0, 0);
        foreach (var item in objectpool.AllpolledObjects["EnemyTier1"])
        {
            if (item.activeInHierarchy)
            {
                float distance = (transform.position - item.transform.position).magnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform.position;
                }
            }
        }
        foreach (var item in objectpool.AllpolledObjects["EnemyTier2"])
        {
            if (item.activeInHierarchy)
            {
                float distance = (transform.position - item.transform.position).magnitude; //расстояние между точками?
                if (distance < min)
                {
                    min = distance;
                    number = item.transform.position;
                }
            }
        }
        return Vector3.Normalize(number - transform.position);
    }
}
