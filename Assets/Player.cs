using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hp = 100f;
    float level = 1;
    float experiens = 0;
    float bonusExp = 0;
    float speed = 1;
    float defence = 0;
    float armor = 0;
    int money = 0;



    protected void ReceiveDamage(float damage)
    {
        
        damage = damage * (1 - defence) - armor;
        if (damage > 0)
            hp = hp - damage;
        if (hp <= 0)
            Death();
    }

    protected void Death()
    {
        //TODO

    }

    protected void ReceiveExp(float exp, float expForLvl)
    {
        experiens = +exp * bonusExp;
        if (experiens >= expForLvl)
        {
            LevelUp();
            experiens= - expForLvl;
        }
    }

    protected void LevelUp()
    {
        level++;
        ChooseWeapon();
        //Choose your bonus function
    }

    protected void ChooseWeapon()
    {

        //how can we get array here?

    }
}
