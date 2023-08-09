

using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "MyScriptable/MyEnemyStats", order = 51)]
public class EnemyStats : ScriptableObject
{

    //RUNTIME!
    //Main
    public float maxhp;
    public float currentHP;   //������� ��������
    public float speed;

    //Resistance
    public float magicResistance;   //������������� �� ����������� �����
    public float phisicResistance;  //�������������� ����������� �����
    public float armor;             //�����
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
    public float regeneration;  //�������������� �������� � �������(?)
    //lvlUp
    public float level;             //������� �������
    public float experiens;         //���� � ������
    //scaling
    public float scalingHp;

}
