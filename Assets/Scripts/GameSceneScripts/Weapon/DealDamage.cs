using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    Vector3 point = new();
    BulletStats stats;
    ChainAttack chain;
    Ricochet ricochet;
    private ObjectPool objectpool;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<BulletStats>();
        objectpool = ObjectPool.Instance;
        chain = GetComponent<ChainAttack>();
        ricochet = GetComponent<Ricochet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
        {
            point = collision.gameObject.transform.position;
            if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemy))
                enemy.GetDamage(stats.damage);

            if (stats.chain)
            {
                chain.Chain(point);
                objectpool.BackToPoll(this.gameObject);
            }



            if (stats.ricochet && stats.ricocount > 0)
                ricochet.RicochetMeh(point);
            else
            {
                stats.ricocount = 2;
                objectpool.BackToPoll(this.gameObject);
            }
 
        }
        }
}
