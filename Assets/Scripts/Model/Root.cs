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