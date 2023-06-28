
using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerStats stats;

    protected void ReceiveDamage(float forceDamage, float magicDamage)
    { 
        float damage = magicDamage * (1 - stats.MagicResistance) - stats.armor + forceDamage * (1 - stats.PhisicResistance) - stats.armor;
        if (damage > 0)
            stats.currentHP = - damage;
        if (stats.currentHP <= 0)
            Death();
    }
    protected void Healing(int heal)
    {
        if (stats.maxhp > stats.currentHP)
        {
            stats.currentHP += heal;
            if (stats.currentHP > stats.maxhp)
                stats.currentHP = stats.maxhp;
        }
    }    
    protected void Regeneration()
    {
        if (stats.maxhp > stats.currentHP)
        {
            stats.currentHP = +stats.regeneration;
        }
    }

    protected void Death()
    {
        //
    }

    protected void ReceiveExp(float exp, float expForLvl)
    {
        stats.experiens = +exp * stats.bonusExp;
        if (stats.experiens >= expForLvl)
        {
            LevelUp();
            stats.experiens = - expForLvl;
        }
    }    
    protected void ReceiveCoin()
    {
        stats.money += 1;
    }


    protected void LevelUp()
    {
        stats.level++;
        stats.maxhp = stats.maxhp * 1.05f;
        ChooseWeapon();
        //Choose your bonus function
    }

    protected void ChooseWeapon()
    {

        //how can we get array here?

    }

    
}
