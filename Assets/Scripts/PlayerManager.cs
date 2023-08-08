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

    //������ ������
    public void DeathPlayer() { 

    }
/*    //��������� �������
    public void ReceiveHeal(float heal) {
        stats.currentHP += heal;
        if (stats.currentHP >= stats.maxhp)
            stats.currentHP = stats.maxhp;
    }*/
    //��������� �����
/*    public void ReceiveExp(float exp) {
        stats.experiens += exp + exp * stats.bonusExp;
        if (stats.experiens >= stats.expForLevel)
        {
            stats.experiens -= stats.expForLevel;
            LevelUp();
        }
        }*/

    //�������� ������
/*    public void LevelUp()
    {
        stats.level++;
        stats.expForLevel *= stats.scaleExpForLevel;
        stats.maxhp *= stats.scalingHp;
        ChooseBonus();
    }*/
    //�����������
/*    public void Regeneration(float regen)
    {

    }

    //����� ������
    public void ChooseBonus() {
    
    }

    //��������� �����
    public void ReceiveMoney()
    {

    }*/

}
