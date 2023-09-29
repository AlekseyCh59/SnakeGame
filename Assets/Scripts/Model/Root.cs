using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class Root
{
    public List<General> General { get; set; }
    public List<Weapon> Weapon { get; set; }
    public List<Enemy> Enemies { get; set; }
    public List<Player> Player { get; set; }
}

public class Enemy
{
    public int idenemy { get; set; }
    public int hp { get; set; }
    public int speed { get; set; }
    public int armor { get; set; }
    public int phisicresistance { get; set; }
    public int magicresistance { get; set; }
    public int fireresistance { get; set; }
    public int iceresistance { get; set; }
    public int lightingresistance { get; set; }
    public int distance { get; set; }
    public int damage { get; set; }
    public int weapontype { get; set; }
    public int cooldown { get; set; }
    public int experience { get; set; }
    public string drop { get; set; }
    public int world { get; set; }
    public int tier { get; set; }
}

public class General
{
    public int idattacktype { get; set; }
    public string attacktype { get; set; }
    public int idweapon { get; set; }
    public string nameweapon { get; set; }
    public int idenemy { get; set; }
    public string nameenemy { get; set; }
    public int idworld { get; set; }
    public string nameworld { get; set; }
}

public class Player
{
    public int maxhp { get; set; }
    public int speed { get; set; }
    public int armor { get; set; }
    public int phisicresisance { get; set; }
    public int magicresisance { get; set; }
    public int fireresisance { get; set; }
    public int iceresisance { get; set; }
    public int lightingresisance { get; set; }
    public bool shield { get; set; }
    public int shieldsize { get; set; }
    public int bonuscooldown { get; set; }
    public int bonusdamage { get; set; }
    public int bonusprojectile { get; set; }
    public int bonuscritchance { get; set; }
    public int bonuscritdamage { get; set; }
    public int bonusfiredamage { get; set; }
    public int bonusicedamage { get; set; }
    public int bonuslightingdamage { get; set; }
    public int bonusmoney { get; set; }
    public int bonusexp { get; set; }
    public int regeneration { get; set; }
    public int level { get; set; }
    public int experience { get; set; }
    public int expforlevel { get; set; }
}

public class Weapon
{
    public int idweapon { get; set; }
    public int level { get; set; }
    public double damage { get; set; }
    public double distance { get; set; }
    public int attacktype { get; set; }
    public int projectile { get; set; }
    public double attackspeed { get; set; }
}
