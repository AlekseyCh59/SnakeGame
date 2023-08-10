using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static UnityEvent<float> OnConsumeExp = new UnityEvent<float>();
    public static UnityEvent<float> OnConsumeFood = new UnityEvent<float>();
    public static UnityEvent<int> OnConsumeCoin = new UnityEvent<int>();
    public static UnityEvent<float> OnPlayerDamage = new UnityEvent<float>();
    public static UnityEvent OnPlayerLevelUp = new UnityEvent();



    public static void SendConsumeFood(float food) {
        OnConsumeFood.Invoke(food);
    }
    public static void SendConsumeCoin(int coin)
    {
        OnConsumeCoin.Invoke(coin);
    }

    public static void SendPlayerLevelUp()
    {
        OnPlayerLevelUp.Invoke();
    }

    public static void SendPlayerDamage(float damage)
    {
        OnPlayerDamage.Invoke(damage);
    }

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
    public static void SendConsumeExp(float exp)
    {
        OnConsumeExp.Invoke(exp);
    }

}
