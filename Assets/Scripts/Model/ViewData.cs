using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class ViewData : MonoBehaviour
{
    [SerializeField] int ID;
    Weapon Weapon = new Weapon();
    [SerializeField] Root root;
    [SerializeField] int level;
    [SerializeField] double damage;
    [SerializeField] double distance;
    
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "root.json"))
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + "root.json"))
            {
                string json = reader.ReadToEnd();
                root = JsonConvert.DeserializeObject<Root>(json);
            }
        }
    }
    private void Update()
    {
        Weapon = root.Weapon[ID];
        level = Weapon.level;
        damage = Weapon.damage;
        distance = Weapon.distance;
        Debug.Log(root.Weapon[ID].level);
    }
}
