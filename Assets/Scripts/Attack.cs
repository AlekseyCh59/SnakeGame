using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float attackInterwal = 1f;

    private IEnumerator weaponAttack(float interwal, GameObject weapon)
    {
        yield return new WaitForSeconds(interwal);
        if (GameObject.FindWithTag("Enemy"))
        {
            GameObject attack = Instantiate(weapon, transform.position, Quaternion.identity);
        }
            StartCoroutine(weaponAttack(interwal, weapon));
      
    }

    private void Start()
    {
        StartCoroutine(weaponAttack(attackInterwal, weapon));
    }
    // Update is called once per frame
    void Update()
    {
      /*  if (timeAttack <= 0)
        {
            timeAttack = 5f;
            Instantiate(Fire, transform.position, transform.rotation);
        }
        timeAttack -= Time.deltaTime;
      */
    }
    }
