using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<float> OnEnemyKilled = new UnityEvent<float>();
    public static UnityEvent<float> OnConsumeExp = new UnityEvent<float>();
    public static UnityEvent<float> OnPlayerDamage = new UnityEvent<float>();


    public static void SendPlayerDamage(float damage)
    {
        OnPlayerDamage.Invoke(damage);
    }

    public static void SendEnemyKilled(float exp)
    {
        OnEnemyKilled.Invoke(exp);
    }
    public static void SendConsumeExp(float exp)
    {
        OnConsumeExp.Invoke(exp);
    }

}
