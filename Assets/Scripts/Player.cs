using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerStats stats;

    protected void ReceiveDamageFromAttack(float forceDamage, float magicDamage)
    { 
        float damage = magicDamage * (1 - stats.MagicResistance) - stats.armor + forceDamage * (1 - stats.PhisicResistance) - stats.armor;
        if (damage > 0)
            stats.currentHP = - damage;
        if (stats.currentHP <= 0)
            Death();
    }    
    
    protected void ReceiveDamageFromBump(int level)
    { 

            stats.currentHP -= level;
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
        
            stats.currentHP =stats.maxhp; //временно
            }

    protected void ReceiveExp(float exp)
    {
        Debug.Log("fgdffg");
        stats.experiens += exp + exp * stats.bonusExp;
        if (stats.experiens >= stats.expForLevel)
        {
            stats.experiens -= stats.expForLevel;
            LevelUp();
           
        }
    }    
    protected void ReceiveCoin()
    {
        stats.money += 1;
    }


    protected void LevelUp()
    {
        
        stats.level++;
        stats.maxhp = stats.maxhp * stats.scalingHp;
        stats.expForLevel = stats.expForLevel * stats.scalingExp;
        ChooseWeapon();
        //Choose your bonus function
    }

    protected void ChooseWeapon()
    {

        //how can we get array here?

    }

    
}
