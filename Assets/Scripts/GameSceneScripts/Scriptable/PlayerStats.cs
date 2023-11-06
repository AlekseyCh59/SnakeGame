/*using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //DELETE THIS



[CreateAssetMenu(fileName = "PlayerStats", menuName = "MyScriptable/MyPlayerStats", order = 51)]
public class PlayerStats : ScriptableObject
{

    public float maxhp { get; set; }
    public float currentHP { get; set; }
    public float speed { get; set; }
    public float armor { get; set; }
    public float phisicresisance { get; set; }
    public float magicresisance { get; set; }
    public float fireresisance { get; set; }
    public float iceresisance { get; set; }
    public float lightingresisance { get; set; }
    public bool shield { get; set; }
    public float shieldsize { get; set; }
    public float bonuscooldown { get; set; }
    public float bonusdamage { get; set; }
    public int bonusprojectile { get; set; }
    public float bonuscritchance { get; set; }
    public float bonuscritdamage { get; set; }
    public float bonusfiredamage { get; set; }
    public float bonusicedamage { get; set; }
    public float bonuslightingdamage { get; set; }
    public float bonusmoney { get; set; }
    public float bonusexp { get; set; }
    public int regeneration { get; set; }
    public int level { get; set; }
    public float experience { get; set; }
    public float expforlevel { get; set; }

    public List<Weapon> playerWeapon =new List<Weapon>();

    

    //����� ��������?
    float scaleExpForLevel;
    public int money;


    //������!!!!
    //��������� �����
    //����� �������� ������ �������� ����� � ��� ����� �����
    public void ReceiveDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP<=0)
        {
            DeathPlayer();
        }
    }

    //��������� �������
    public void ReceiveHeal(float heal)
    {
        currentHP += heal;
        if (currentHP >= maxhp)
            currentHP = maxhp;
    }
    //��������� �����
    public void ReceiveExp(float exp)
    {
        experience += exp + exp * bonusexp;
        if (experience >= expforlevel)
        {
            experience -= expforlevel;
            LevelUp();
        }
    }
    //�������� ������
    public void LevelUp()
    {
        GlobalEventManager.SendPlayerLevelUp();
        level++;
        expforlevel = (float)Math.Exp((double)expforlevel);
        maxhp *= 1.15f; 
        currentHP=maxhp;
        playerWeapon.Add(StatRoot.Weapon[0]);
        //ChooseBonus();
    }

    //�����������
    public void Regeneration(float regen)
    {

    }

    //����� ������
    public void ChooseBonus()
    {

    }

    //��������� �����
    public void ReceiveMoney(int coin)
    {

        money += coin;
    }

    //������ ������
    public void DeathPlayer()
    {
        SceneManager.LoadScene("MenuScene");
    }

}

*/