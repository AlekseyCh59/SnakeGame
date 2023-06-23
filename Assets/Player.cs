using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float hp = 100f;
    [SerializeField] protected float level = 1;
    [SerializeField] protected float experiens = 0;
    [SerializeField] protected float bonusExp = 0;
    [SerializeField] protected float Speed = 2;
    [SerializeField] protected float MagicalDefence = 0;
    [SerializeField] protected float PhysicalDefence = 0;
    [SerializeField] protected float armor = 0;
    [SerializeField] protected int money = 0;






    protected void ReceiveDamage(float ForceDamage, string VariableDamage)
    {
        if(VariableDamage=="Magic")
            ForceDamage = ForceDamage * (1 - MagicalDefence) - armor;
        if (VariableDamage == "Might")
            ForceDamage = ForceDamage * (1 - PhysicalDefence) - armor;
        if (ForceDamage > 0)
            hp = hp - ForceDamage;
        if (hp <= 0)
            Death();
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
