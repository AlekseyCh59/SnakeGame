using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerStats stats;

    List<Weapon> playerWeapon= new List<Weapon>();




    private void Awake()
    {
        

    }
    private void Update()
    {
      
    }



    private void Start()
    {
        //playerWeapon.Add(StatRoot.Weapon[0]);
    }

    /*    public void ReceiveDamage(float damage)
        {
            stats.currentHP -= damage;
        }*/


/*    //Получение лечения
    public void ReceiveHeal(float heal) {
        stats.currentHP += heal;
        if (stats.currentHP >= stats.maxhp)
            stats.currentHP = stats.maxhp;
    }*/
    //Получение опыта
/*    public void ReceiveExp(float exp) {
        stats.experiens += exp + exp * stats.bonusExp;
        if (stats.experiens >= stats.expForLevel)
        {
            stats.experiens -= stats.expForLevel;
            LevelUp();
        }
        }*/

    //Поднятие уровня
/*    public void LevelUp()
    {
        stats.level++;
        stats.expForLevel *= stats.scaleExpForLevel;
        stats.maxhp *= stats.scalingHp;
        ChooseBonus();
    }*/
    //Регенерация
/*    public void Regeneration(float regen)
    {

    }

    //Выбор бонуса
    public void ChooseBonus() {
    
    }

    //Получение монет
    public void ReceiveMoney()
    {

    }*/

}
