using System;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerStats", menuName = "MyScriptable/MyPlayerStats", order = 51)]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    //Main
    public float maxhpInitialValue;
    public float currentHPInitialValue;   //������� ��������
    public float speedInitialValueInitialValue;
    public int money;           //������ ������ ��� �������� ����� ��������(?) ��� ������������(?)
    //Resistance
    public float magicResistanceInitialValue;   //������������� �� ����������� �����
    public float phisicResistanceInitialValue;  //�������������� ����������� �����
    public float armorInitialValue;             //�����
    public float fireResistanceInitialValue;
    public float iceResistanceInitialValue;
    public float lightingResistanceInitialValue;
    public float poisonResistanceInitialValue;
    public float bleedResistanceInitialValue;
    public bool shieldInitialValue;
    public float shieldSizeInitialValue;
    //Damage
    public float reloadRateInitialValue;
    public int bonusprojectileInitialValue; //�������� �������
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
    public float bonusExpInitialValue;      //�������� ���� �� �������� �����
    public float regenerationInitialValue;  //�������������� �������� � �������(?)


    //lvlUp
    public float levelInitialValue;             //������� �������
    public float experiensInitialValue;         //���� � ������
    public float expForLevelInitialValue; //����� ��� ��������� ������ 
    public float scaleExpForLevelInitialValue;

    //scaling
    public float scalingHpInitialValue;
    public float scalingExpInitialValue;    //�������� ����� ��� ������



    //RUNTIME!

    //Main
    [NonSerialized] public float maxhp;
    [NonSerialized] public float currentHP;   //������� ��������
    [NonSerialized] public float speed;

    //Resistance
    [NonSerialized] public float magicResistance;   //������������� �� ����������� �����
    [NonSerialized] public float phisicResistance;  //�������������� ����������� �����
    [NonSerialized] public float armor;             //�����
    [NonSerialized] public float fireResistance;
    [NonSerialized] public float iceResistance;
    [NonSerialized] public float lightingResistance;
    [NonSerialized] public float poisonResistance;
    [NonSerialized] public float bleedResistance;
    [NonSerialized] public bool shield;
    [NonSerialized] public float shieldSize;
    //Damage
    [NonSerialized] public float reloadRate;
    [NonSerialized] public int bonusprojectile; //�������� �������
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
    [NonSerialized] public float bonusExp;      //�������� ���� �� �������� �����
    [NonSerialized] public float regeneration;  //�������������� �������� � �������(?)


    //lvlUp
    [NonSerialized] public float level;             //������� �������
    [NonSerialized] public float experiens;         //���� � ������
    [NonSerialized] public float expForLevel; //����� ��� ��������� ������ 
    [NonSerialized] public float scaleExpForLevel;

    //scaling
    [NonSerialized] public float scalingHp;
    [NonSerialized] public float scalingExp;






    public void OnAfterDeserialize()
    {
        //Main
        maxhp = maxhpInitialValue;
        currentHP = currentHPInitialValue;   //������� ��������
        speed = speedInitialValueInitialValue;
        //Resistance
        magicResistance = magicResistanceInitialValue;   //������������� �� ����������� �����
        phisicResistance = phisicResistanceInitialValue;  //�������������� ����������� �����
        armor = armorInitialValue;             //�����
        fireResistance = fireResistanceInitialValue;
        iceResistance = iceResistanceInitialValue;
        lightingResistance = lightingResistanceInitialValue;
        poisonResistance = poisonResistanceInitialValue;
        bleedResistance = bleedResistanceInitialValue;
        shield = shieldInitialValue;
        shieldSize = shieldSizeInitialValue;
        //Damage
        reloadRate = reloadRateInitialValue;
        bonusCritDamage = bonusprojectileInitialValue; //�������� �������
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
        bonusExp = bonusExpInitialValue;      //�������� ���� �� �������� �����
        regeneration = regenerationInitialValue;  //�������������� �������� � �������(?)


        //lvlUp
        level = levelInitialValue;             //������� �������
        experiens = experiensInitialValue;         //���� � ������
        expForLevel = expForLevelInitialValue; //����� ��� ��������� ������ 
        scaleExpForLevel = scaleExpForLevelInitialValue;

        //scaling
        scalingHp = scalingHpInitialValue;
        scalingExp = scalingExpInitialValue;    //�������� ����� ��� ������

    }



    public void OnBeforeSerialize() { }
}

