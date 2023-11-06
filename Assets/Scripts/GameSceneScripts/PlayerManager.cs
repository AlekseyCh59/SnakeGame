using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
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

    public List<Weapon> playerWeapon = new List<Weapon>();
    //Нужно добавить?
    float scaleExpForLevel;
    public int money;





    private void Awake()
    {
        Init();
        GlobalEventManager.OnPlayerDamage += ReceiveDamage;
        GlobalEventManager.OnConsumeExp += ReceiveExp;
        GlobalEventManager.OnConsumeFood += ReceiveHeal;
        GlobalEventManager.OnConsumeCoin += ReceiveMoney;

    }
    private void Update()
    {
      
    }

    private void Start()
    {
        //playerWeapon.Add(StatRoot.Weapon[0]);
    }
    private void Init()
    {
        maxhp = StatRoot.Player[0].maxhp;
        currentHP = StatRoot.Player[0].maxhp;
        speed = StatRoot.Player[0].speed;
        armor = StatRoot.Player[0].armor;
        phisicresisance = StatRoot.Player[0].phisicresisance;
        magicresisance = StatRoot.Player[0].magicresisance;
        fireresisance = StatRoot.Player[0].fireresisance;
        iceresisance = StatRoot.Player[0].iceresisance;
        lightingresisance = StatRoot.Player[0].lightingresisance;
        shield = StatRoot.Player[0].shield;
        shieldsize = StatRoot.Player[0].shieldsize;
        bonuscooldown = StatRoot.Player[0].bonuscooldown;
        bonusdamage = StatRoot.Player[0].bonusdamage;
        bonusprojectile = StatRoot.Player[0].bonusprojectile;
        bonuscritchance = StatRoot.Player[0].bonuscritchance;
        bonuscritdamage = StatRoot.Player[0].bonuscritdamage;
        bonusfiredamage = StatRoot.Player[0].bonusfiredamage;
        bonusicedamage = StatRoot.Player[0].bonusicedamage;
        bonuslightingdamage = StatRoot.Player[0].bonuslightingdamage;
        bonusmoney = StatRoot.Player[0].bonusmoney;
        bonusexp = StatRoot.Player[0].bonusexp;
        regeneration = StatRoot.Player[0].regeneration;
        level = StatRoot.Player[0].level;
        experience = StatRoot.Player[0].experience;
        expforlevel = StatRoot.Player[0].expforlevel;
    }



    public void ReceiveDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {

            //DeathPlayer();
        }
    }

    //Получение лечения
    public void ReceiveHeal(float heal)
    {
        currentHP += heal;
        if (currentHP >= maxhp)
            currentHP = maxhp;
    }
    //Получение опыта
    public void ReceiveExp(float exp)
    {
        experience += exp + exp * bonusexp;
        if (experience >= expforlevel)
        {
            experience -= expforlevel;
            LevelUp();
        }
    }
    //Поднятие уровня
    public void LevelUp()
    {
        GlobalEventManager.SendPlayerLevelUp();
        level++;
        expforlevel *= 1.6f;
        maxhp *= 1.15f;
        currentHP = maxhp;
        playerWeapon.Add(StatRoot.Weapon[0]);
        //ChooseBonus();
    }

    //Регенерация
    public void Regeneration(float regen)
    {

    }

    //Выбор бонуса
    public void ChooseBonus()
    {

    }

    //Получение монет
    public void ReceiveMoney(int coin)
    {

        money += coin;
    }

    //Смерть игрока
    public void DeathPlayer()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
