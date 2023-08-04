using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<float> OnEnemyKilled = new UnityEvent<float>();
    public static UnityEvent<string> OnConsume = new UnityEvent<string>();

    public static void SendEnemyKilled(float exp)
    {
        OnEnemyKilled.Invoke(exp);
    }
    public static void SendConsume(string tag)
    {
        OnConsume.Invoke(tag);
    }

}
