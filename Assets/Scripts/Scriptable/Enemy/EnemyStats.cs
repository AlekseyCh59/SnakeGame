

using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "MyScriptable/MyEnemyStats", order = 51)]
public class EnemyStats : ScriptableObject
{

    //RUNTIME!
    //Main
    public float maxhp;
    public float currentHP;   //текущее здоровье
    public float speed;

    //Resistance
    public float magicResistance;   //сопротивление не физическому урону
    public float phisicResistance;  //сопротивлкение физическому урону
    public float armor;             //броня
    public float fireResistance;
    public float iceResistance;
    public float lightingResistance;
    public float poisonResistance;
    public float bleedResistance;
    public bool shield;
    public float shieldSize;
    //Damage
    public float damage;
    public string damageType;

    //Other bonuses
    public float regeneration;  //восстановление здоровья в секунду(?)
    //lvlUp
    public float level;             //текущий уровень
    public float experiens;         //опыт у игрока
    //scaling
    public float scalingHp;

}
