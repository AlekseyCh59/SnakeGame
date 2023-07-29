using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<GameObject> OnEnemyKilled = new UnityEvent<GameObject>();

    public static void SendEnemyKilled(GameObject obj)
    {
        OnEnemyKilled.Invoke(obj);
    }  

}
