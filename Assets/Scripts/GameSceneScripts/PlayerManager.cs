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
