using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]GameObject Fire;
    float timeAttack=5f;
    // Update is called once per frame
    void Update()
    {
        if (timeAttack <= 0)
        {
            timeAttack = 5f;
            Instantiate(Fire, transform.position, transform.rotation);
        }
        timeAttack -= Time.deltaTime;
    }
}
