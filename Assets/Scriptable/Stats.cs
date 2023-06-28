
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "MyScriptable/MyStats", order = 51)]
public class Stats : ScriptableObject
{

    public float currentHP = 100f;   //������� ��������
    public float maxhp = 100f;          //������������ ��������
    public float level = 1;             //������� �������
    public float experiens = 0;         //���� � ������ / ���� �� �����
    public float Speed = 200;             //�������� ������ / ����������
    public float MagicResistance = 0;   //������������� �� ����������� �����
    public float PhisicResistance = 0;  //�������������� ����������� �����
    public float armor = 0;             //�����
    public Sprite sprite;               //������


}
