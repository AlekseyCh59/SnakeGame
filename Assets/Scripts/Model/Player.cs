using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
