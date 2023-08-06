
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "MyScriptable/MyEnemyStats", order = 51)]
public class EnemyStats : ScriptableObject
{
    //Main
    public float maxhp = 10;
    public float currentHP = 10; //текущее здоровье
    public float speed = 10;
    public int money = 0;           //деньги игрока для магазина между уровнями(?) или метапрокачки(?)
    //Resistance
    public float magicResistance = 0;   //сопротивление не физическому урону
    public float phisicResistance = 0;  //сопротивлкение физическому урону
    public float armor = 0;             //броня
    public float fireResistance = 0;
    public float iceResistance = 0;
    public float lightingResistance = 0;
    public float poisonResistance = 0;
    public float bleedResistance = 0;
    public bool shield = false;
    public float shieldSize = 100;
    //Damage
    public float damage;
    public float reloadRate = 1;
    public int bonusprojectile = 0; //бунусные снаряды
    public float critChance = 1;
    public float bonusCritDamage = 1.5f;
    public float iceDamage = 1;
    public float fireDamage = 1;
    public float lightingDamage = 1;
    public float magicDamage = 1;
    public float phisicDamage = 1;
    public float poisonDamage = 1;
    public float bleedDamage = 1;

    //Other bonuses
    public int bonusmoney = 1;
    public float bonusExp = 1;      //бонусный опыт за убийство врага
    public float regeneration = 0;  //восстановление здоровья в секунду(?)


    //lvlUp
    public float level = 0;             //текущий уровень
    public float experiens = 0;         //опыт у игрока
    public float expForLevel = 100f; //опыта для получения уровня 
    public float scaleExpForLevel = 2;

    //scaling
    public float scalingHp = 1.05f;
    public float scalingExp = 1;    //скейлинг опыта для лвлава

}
