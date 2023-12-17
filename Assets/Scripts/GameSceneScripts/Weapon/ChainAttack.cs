using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttack : MonoBehaviour
{
    int CountEnemies = 3;
    List<GameObject> Enemies = new();
    float radius = 10f;
    public GameObject enemy = null;
    private ObjectPool objectpool;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        objectpool = ObjectPool.Instance;
        line.startWidth = 2f;
        line.endWidth = 2f;
        line.positionCount = 0;
        line.startColor= Color.red;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
        {
            if (Enemies.Count < CountEnemies+1)
            {
                line.positionCount++;
                line.SetPosition(line.positionCount, collision.gameObject.transform.position);
                Enemies.Add(collision.gameObject);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
                float min = float.MaxValue;
                foreach (var item in colliders)
                {
                    if (item.tag.Contains("Enemy") && !Enemies.Contains(item.gameObject))
                    {
                        float distance = (item.gameObject.transform.position - this.transform.position).sqrMagnitude;
                        if (min > distance)
                        {
                            min = distance;
                            enemy = item.gameObject;
                        }
                    }
                }
                if (min != float.MaxValue)
                {
                    this.transform.position = enemy.transform.position;
                }
            }
            else
            {
                line.positionCount = 0;
            }
        }

        //objectpool.BackToPoll(this.gameObject);

    }
}
