using System;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerStats", menuName = "MyScriptable/MyPlayerStats", order = 51)]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    //Main
    public float maxhpInitialValue;
    public float currentHPInitialValue;   //текущее здоровье
    public float speedInitialValueInitialValue;
    public int money;           //деньги игрока для магазина между уровнями(?) или метапрокачки(?)
    //Resistance
    public float magicResistanceInitialValue;   //сопротивление не физическому урону
    public float phisicResistanceInitialValue;  //сопротивлкение физическому урону
    public float armorInitialValue;             //броня
    public float fireResistanceInitialValue;
    public float iceResistanceInitialValue;
    public float lightingResistanceInitialValue;
    public float poisonResistanceInitialValue;
    public float bleedResistanceInitialValue;
    public bool shieldInitialValue;
    public float shieldSizeInitialValue;
    //Damage
    public float reloadRateInitialValue;
    public int bonusprojectileInitialValue; //бунусные снаряды
    public float critChanceInitialValue;
    public float bonusCritDamageInitialValue;
    public float iceDamageInitialValue;
    public float fireDamageInitialValue;
    public float lightingDamageInitialValue;
    public float magicDamageInitialValue;
    public float phisicDamageInitialValue;
    public float poisonDamageInitialValue;
    public float bleedDamageInitialValue;

    //Other bonuses
    public int bonusmoneyInitialValue;
    public float bonusExpInitialValue;      //бонусный опыт за убийство врага
    public float regenerationInitialValue;  //восстановление здоровья в секунду(?)


    //lvlUp
    public float levelInitialValue;             //текущий уровень
    public float experiensInitialValue;         //опыт у игрока
    public float expForLevelInitialValue; //опыта для получения уровня 
    public float scaleExpForLevelInitialValue;

    //scaling
    public float scalingHpInitialValue;
    public float scalingExpInitialValue;    //скейлинг опыта для лвлава



    //RUNTIME!

    //Main
    [NonSerialized] public float maxhp;
    [NonSerialized] public float currentHP;   //текущее здоровье
    [NonSerialized] public float speed;

    //Resistance
    [NonSerialized] public float magicResistance;   //сопротивление не физическому урону
    [NonSerialized] public float phisicResistance;  //сопротивлкение физическому урону
    [NonSerialized] public float armor;             //броня
    [NonSerialized] public float fireResistance;
    [NonSerialized] public float iceResistance;
    [NonSerialized] public float lightingResistance;
    [NonSerialized] public float poisonResistance;
    [NonSerialized] public float bleedResistance;
    [NonSerialized] public bool shield;
    [NonSerialized] public float shieldSize;
    //Damage
    [NonSerialized] public float reloadRate;
    [NonSerialized] public int bonusprojectile; //бунусные снаряды
    [NonSerialized] public float critChance;
    [NonSerialized] public float bonusCritDamage;
    [NonSerialized] public float iceDamage;
    [NonSerialized] public float fireDamage;
    [NonSerialized] public float lightingDamage;
    [NonSerialized] public float magicDamage;
    [NonSerialized] public float phisicDamage;
    [NonSerialized] public float poisonDamage;
    [NonSerialized] public float bleedDamage;

    //Other bonuses
    [NonSerialized] public int bonusmoney;
    [NonSerialized] public float bonusExp;      //бонусный опыт за убийство врага
    [NonSerialized] public float regeneration;  //восстановление здоровья в секунду(?)


    //lvlUp
    [NonSerialized] public float level;             //текущий уровень
    [NonSerialized] public float experiens;         //опыт у игрока
    [NonSerialized] public float expForLevel; //опыта для получения уровня 
    [NonSerialized] public float scaleExpForLevel;

    //scaling
    [NonSerialized] public float scalingHp;
    [NonSerialized] public float scalingExp;






    public void OnAfterDeserialize()
    {
        //Main
        maxhp = maxhpInitialValue;
        currentHP = currentHPInitialValue;   //текущее здоровье
        speed = speedInitialValueInitialValue;
        //Resistance
        magicResistance = magicResistanceInitialValue;   //сопротивление не физическому урону
        phisicResistance = phisicResistanceInitialValue;  //сопротивлкение физическому урону
        armor = armorInitialValue;             //броня
        fireResistance = fireResistanceInitialValue;
        iceResistance = iceResistanceInitialValue;
        lightingResistance = lightingResistanceInitialValue;
        poisonResistance = poisonResistanceInitialValue;
        bleedResistance = bleedResistanceInitialValue;
        shield = shieldInitialValue;
        shieldSize = shieldSizeInitialValue;
        //Damage
        reloadRate = reloadRateInitialValue;
        bonusCritDamage = bonusprojectileInitialValue; //бунусные снаряды
        critChance = critChanceInitialValue;
        bonusCritDamage = bonusCritDamageInitialValue;
        iceDamage = iceDamageInitialValue;
        fireDamage = fireDamageInitialValue;
        lightingDamage = lightingDamageInitialValue;
        magicDamage = magicDamageInitialValue;
        phisicDamage = phisicDamageInitialValue;
        poisonDamage = poisonDamageInitialValue;
        bleedDamage = bleedDamageInitialValue;

        //Other bonuses
        bonusmoney = bonusmoneyInitialValue;
        bonusExp = bonusExpInitialValue;      //бонусный опыт за убийство врага
        regeneration = regenerationInitialValue;  //восстановление здоровья в секунду(?)


        //lvlUp
        level = levelInitialValue;             //текущий уровень
        experiens = experiensInitialValue;         //опыт у игрока
        expForLevel = expForLevelInitialValue; //опыта для получения уровня 
        scaleExpForLevel = scaleExpForLevelInitialValue;

        //scaling
        scalingHp = scalingHpInitialValue;
        scalingExp = scalingExpInitialValue;    //скейлинг опыта для лвлава

    }



    public void OnBeforeSerialize() { }
}

