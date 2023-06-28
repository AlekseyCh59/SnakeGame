using UnityEngine;



[CreateAssetMenu(fileName = "PlayerStats", menuName = "MyScriptable/MyPlayerStats", order = 51)]
public class PlayerStats : Stats
{
    public int money = 0;           //������ ������ ��� �������� ����� ��������(?) ��� ������������(?)
    public float regeneration = 0;  //�������������� �������� � �������(?)
    public float bonusExp = 0;      //�������� ���� �� �������� �����
    public int bonusprojectile = 0; //�������� �������
    public int bonusmoney = 0; //����� � �������
    public float currentHP = 100f;   //������� ��������


}
