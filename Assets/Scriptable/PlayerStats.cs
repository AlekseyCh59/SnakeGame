using UnityEngine;



[CreateAssetMenu(fileName = "PlayerStats", menuName = "MyScriptable/MyPlayerStats", order = 51)]
public class PlayerStats : Stats
{
    public int money = 0;           //деньги игрока для магазина между уровнями(?) или метапрокачки(?)
    public float regeneration = 0;  //восстановление здоровья в секунду(?)
    public float bonusExp = 0;      //бонусный опыт за убийство врага
    public int bonusprojectile = 0; //бунусные снаряды
    public int bonusmoney = 0; //бонус к деньгам
    public float currentHP = 100f;   //текущее здоровье


}
