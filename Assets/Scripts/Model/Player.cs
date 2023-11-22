using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player
{

    public int maxhp { get; set; }
    public int currentHP { get; set; }
    public float speed { get; set; }
    public float armor { get; set; }
    public float phisicresisance { get; set; }
    public float magicresisance { get; set; }
    public float fireresisance { get; set; }
    public float iceresisance { get; set; }
    public float lightingresisance { get; set; }
    public bool shield { get; set; }
    public float shieldsize { get; set; }
    public float bonuscooldown { get; set; }
    public float bonusdamage { get; set; }
    public int bonusprojectile { get; set; }
    public float bonuscritchance { get; set; }
    public float bonuscritdamage { get; set; }
    public float bonusfiredamage { get; set; }
    public float bonusicedamage { get; set; }
    public float bonuslightingdamage { get; set; }
    public float bonusmoney { get; set; }
    public float bonusexp { get; set; }
    public int regeneration { get; set; }
    public int level { get; set; }
    public float experience { get; set; }
    public float expforlevel { get; set; }
}
