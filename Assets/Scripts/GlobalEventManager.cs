using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<GameObject> OnEnemyKilled = new UnityEvent<GameObject>();
    public static UnityEvent<string> OnConsume = new UnityEvent<string>();

    public static void SendEnemyKilled(GameObject obj)
    {
        OnEnemyKilled.Invoke(obj);
    }
    public static void SendConsume(string tag)
    {
        OnConsume.Invoke(tag);
    }

}
