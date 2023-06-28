
using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerStats stats;
    protected float currentHP;
    private void Start()
    {
        currentHP = stats.maxhp-10;
}
    protected void ReceiveDamage(float forceDamage, float magicDamage)
    { 
        float damage = magicDamage * (1 - stats.MagicResistance) - stats.armor + forceDamage * (1 - stats.PhisicResistance) - stats.armor;
        if (damage > 0)
            currentHP = - damage;
        if (currentHP <= 0)
            Death();
    }
    public void Healing(int heal)
    {
        if (stats.maxhp > currentHP)
        {
            currentHP += heal;
            if (currentHP > stats.maxhp)
                currentHP = stats.maxhp;
        }
    }    
    protected void Regeneration()
    {
        if (stats.maxhp > currentHP)
        {
            currentHP = +stats.regeneration;
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
        stats.money = +1;
    }


    protected void LevelUp()
    {
        stats.level++;
        ChooseWeapon();
        //Choose your bonus function
    }

    protected void ChooseWeapon()
    {

        //how can we get array here?

    }

    
}
