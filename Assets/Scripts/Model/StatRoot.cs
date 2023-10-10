using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public static class StatRoot
{
    public static List<General> General { get; set; }
    public static List<Weapon> Weapon { get; set; }
    public static List<Enemy> Enemies { get; set; }
    public static List<Player> Player { get; set; }
}