
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "MyScriptable/MyEnemyStats", order = 51)]
public class EnemyStats : ScriptableObject
{
    //Main
    public float maxhp = 10;
    public float currentHP = 10; //������� ��������
    public float speed = 10;
    public int money = 0;           //������ ������ ��� �������� ����� ��������(?) ��� ������������(?)
    //Resistance
    public float magicResistance = 0;   //������������� �� ����������� �����
    public float phisicResistance = 0;  //�������������� ����������� �����
    public float armor = 0;             //�����
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
    public int bonusprojectile = 0; //�������� �������
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
    public float bonusExp = 1;      //�������� ���� �� �������� �����
    public float regeneration = 0;  //�������������� �������� � �������(?)


    //lvlUp
    public float level = 0;             //������� �������
    public float experiens = 0;         //���� � ������
    public float expForLevel = 100f; //����� ��� ��������� ������ 
    public float scaleExpForLevel = 2;

    //scaling
    public float scalingHp = 1.05f;
    public float scalingExp = 1;    //�������� ����� ��� ������

}
