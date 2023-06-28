
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "MyScriptable/MyStats", order = 51)]
public class Stats : ScriptableObject
{

    public float currentHP = 100f;   //текущее здоровье
    public float maxhp = 100f;          //максимальное здоровье
    public float level = 1;             //текущий уровень
    public float experiens = 0;         //опыт у игрока / опыт за врага
    public float Speed = 200;             //скорость игрока / противника
    public float MagicResistance = 0;   //сопротивление не физическому урону
    public float PhisicResistance = 0;  //сопротивлкение физическому урону
    public float armor = 0;             //броня
    public Sprite sprite;               //спрайт


}
