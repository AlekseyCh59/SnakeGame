using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : MonoBehaviour
{
    private BulletStats stats;
    private ObjectPool objectpool;
    private MoveToEnemy moveTo;

    public void RicochetMeh(Vector3 point)
    {
        GameObject enemy = null;
        float min = float.MaxValue;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, stats.distance);
        foreach (var item in colliders)
        {
            if (item.tag.Contains("Enemy"))
            {
                float distrance = (this.gameObject.transform.position - item.gameObject.transform.position).sqrMagnitude;

                if (min > distrance && item.gameObject.transform.position != point && distrance > 0)
                {
                    min = distrance;
                    enemy = item.gameObject;
                }
            }        
        }
        stats.ricocount -= 1;
        if (enemy != null && enemy.activeInHierarchy)
        moveTo.direct = (enemy.transform.position-this.transform.position).normalized;
    }
    private void Start()
    {
        stats = GetComponent<BulletStats>();
        objectpool = ObjectPool.Instance;
        moveTo = GetComponent<MoveToEnemy>();
    }
}
