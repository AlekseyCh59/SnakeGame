using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttack : MonoBehaviour
{
    BulletStats stats;
    int CountEnemies = 3;
    List<Vector3> Enemies = new();
    float chainDamage = 0.75f;
    public GameObject enemy = null;
    private ObjectPool objectpool;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<BulletStats>();
        objectpool = ObjectPool.Instance;
    }
    private void OnEnable()
    {
        chainDamage = 0.75f;
    }
    public void Chain(Vector3 startPosition)
    {
        stats.line.positionCount = 0;
        Enemies.Add(startPosition);
        while (Enemies.Count<CountEnemies)
        {
            enemy = null;
            GetNewEnemy(Enemies[^1]);
            if (enemy != null)
            {
                if (enemy.TryGetComponent<EnemyScript>(out EnemyScript nextEnemy))
                    nextEnemy.GetDamage(stats.damage * chainDamage);
                chainDamage /= 2;
            }
            else
            {
                break;
            }
        }
        DrawLine();

    }

    private void GetNewEnemy(Vector3 target)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(target, stats.distance);
        float min = float.MaxValue;
        foreach (var item in colliders)
        {
            if (item.tag.Contains("Enemy") && !Enemies.Contains(item.gameObject.transform.position))
            {
                float distance = (item.gameObject.transform.position - target).sqrMagnitude;
                if (min > distance)
                {
                    min = distance;
                    enemy = item.gameObject;
                }
            }
        }
        if(enemy!=null)
        Enemies.Add(enemy.transform.position);

    }

    private void DrawLine()
    {

        stats.line.positionCount = Enemies.Count;
        for (int i = 0; i < stats.line.positionCount; i++)
        {
            stats.line.SetPosition(i, Enemies[i]);
        }
        Enemies.Clear();
    }
}
