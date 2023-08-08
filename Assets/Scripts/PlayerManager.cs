using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerStats stats;


    private void Awake()
    {
        
        GlobalEventManager.OnPlayerDamage.AddListener(stats.ReceiveDamage);     
        GlobalEventManager.OnConsumeExp.AddListener(stats.ReceiveExp);
    }

    private void Start()
    {
        stats.LevelUp();
    }

    /*    public void ReceiveDamage(float damage)
        {
            stats.currentHP -= damage;
        }*/

    //Смерть игрока
    public void DeathPlayer() { 

    }
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
