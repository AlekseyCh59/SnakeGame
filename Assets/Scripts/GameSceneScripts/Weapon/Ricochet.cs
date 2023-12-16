using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : MonoBehaviour
{
    public GameObject GetNewTarget(float radius, Collider2D colis)
    {
        GameObject enemy = null;
        float min = float.MaxValue;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
        foreach (var item in colliders)
        {
            if (item.tag.Contains("Enemy"))
            {
                float distrance = (this.gameObject.transform.position - item.gameObject.transform.position).sqrMagnitude;

                if (min > distrance && item.gameObject != colis.gameObject && distrance > 0)
                {
                    min = distrance;
                    enemy = item.gameObject;

                }
            }
           
        }
        return enemy;
    }
               
}
