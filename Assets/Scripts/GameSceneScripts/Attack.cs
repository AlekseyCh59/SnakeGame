using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private ObjectPool objectpool;

    private void Awake()
    {
        objectpool = ObjectPool.Instance;
    }

    private void Start()
    {
        StartCoroutine(SpawnFire(1));
    }
    private IEnumerator SpawnFire(float interwal)
    {
        yield return new WaitForSeconds(interwal);
        objectpool.SpawnFromPool("Fire",transform.position, transform.rotation);
        StartCoroutine(SpawnFire(interwal));
    }
}
