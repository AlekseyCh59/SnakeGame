
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "MyScriptable/MyStats", order = 51)]
public class Stats : ScriptableObject
{

    public float healthPoints = 100f;
    public float maxhp = 100f;
    public float regeneration = 0;
    public float level = 1;
    public float experiens = 0;
    public float bonusExp = 0;
    public float Speed = 2;
    public float MagicResistance = 0;
    public float PhisicResistance = 0;
    public float armor = 0;
    public int money = 0;

    public Sprite sprite;


}
