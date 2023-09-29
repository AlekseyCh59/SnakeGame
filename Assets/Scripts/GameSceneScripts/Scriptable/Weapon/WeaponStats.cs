
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "MyScriptable/WeaponStats", order = 51), Serializable]
public class WeaponStats : ScriptableObject
{
    public int idweapon=0;
    public int level=0;
    public double damage=0;
    public double distance=0;
    public int attacktype=0;
    public int projectile=0;
    public double attackspeed=0;
}
