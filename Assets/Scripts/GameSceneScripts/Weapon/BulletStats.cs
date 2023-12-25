using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public float damage { get; private set; }
    public float distance { get; private set; }
    public float speed { get; private set; }
    public float lifetime { get; private set; }
    public GameObject enemy { get;  set; }

    public LineRenderer line;
    //MODS
    public bool chain = false;
    public bool ricochet = true;
    public int ricocount = 2;


    public void GetStats(float _damage, float _distance, float _speed, float _lifetime, GameObject _enemy)
    {
        damage = _damage;
        distance = _distance;
        speed = _speed;
        lifetime = _lifetime;
        enemy = _enemy;
    }

}
