using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEventManager
{
    //C# events
    public static event Action<GameObject> OnEnemyKilled;
    public static event Action<GameObject> OnEnemySpawned;
    public static event Action<float> OnConsumeExp;
    public static event Action<float> OnConsumeFood;
    public static event Action<int> OnConsumeCoin;
    public static event Action<float> OnPlayerDamage;
    public static event Action OnPlayerLevelUp;
 


    public static void SendEnemyKilled(GameObject enemy)
    {
        OnEnemyKilled?.Invoke(enemy);
    }

    public static void SendEnemySpawn(GameObject enemy)
    {
        OnEnemySpawned?.Invoke(enemy);
    }
    public static void SendConsumeFood(float food) {
        OnConsumeFood?.Invoke(food);
    }

    public static void SendConsumeCoin(int coin)
    {
        OnConsumeCoin?.Invoke(coin);
    }

    public static void SendPlayerLevelUp()
    {
        OnPlayerLevelUp?.Invoke();
    }

    public static void SendPlayerDamage(float damage)
    {
        OnPlayerDamage?.Invoke(damage);
    }


    public static void SendConsumeExp(float exp)
    {
        OnConsumeExp?.Invoke(exp);
    }

}
