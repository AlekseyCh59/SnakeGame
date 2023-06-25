using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] protected float healthPoints = 100f;
    [SerializeField] protected float maxhp = 100f;
    [SerializeField] protected float regeneration = 0;
    [SerializeField] protected float level = 1;
    [SerializeField] protected float experiens = 0;
    [SerializeField] protected float bonusExp = 0;
    [SerializeField] protected float Speed = 2;
    [SerializeField] protected float MagicResistance = 0;
    [SerializeField] protected float PhisicResistance = 0;
    [SerializeField] protected float armor = 0;
    [SerializeField] protected int money = 0;






    protected void ReceiveDamage(float forceDamage, float magicDamage)
    { 
        float damage = magicDamage * (1 - MagicResistance) - armor + forceDamage * (1 - PhisicResistance) - armor;
        if (damage > 0)
            healthPoints = - damage;
        if (healthPoints <= 0)
            Death();
    }
    protected void Healing(float heal)
    {
        if (maxhp > healthPoints)
        {
            healthPoints = +heal;
            if (healthPoints > maxhp)
                healthPoints = maxhp;
        }
    }    
    protected void Regeneration()
    {
        if (maxhp > healthPoints)
        {
            healthPoints = +regeneration;
        }
    }

    protected void Death()
    {
        //
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
    protected void ReceiveCoin()
    {
        money = +1;
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
