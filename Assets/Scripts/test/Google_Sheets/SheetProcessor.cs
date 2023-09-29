using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;

public class SheetProcessor : MonoBehaviour
{

    public Root root;
    public void ProcessData(string cvsRawData)
    {
        cvsRawData = cvsRawData.Replace("\"\"", "\"");
        cvsRawData = cvsRawData.Remove(0, 1);
        cvsRawData = cvsRawData.Remove(cvsRawData.Length - 2, 2);
        //Debug.Log((WeaponStats)JsonUtility.FromJson(cvsRawData, typeof(WeaponStats)));
        root = JsonConvert.DeserializeObject<Root>(cvsRawData);
        Debug.Log(root.Enemies[0].armor);
        Debug.Log(root.Weapon[0].level);
        Debug.Log(root.Player[0].speed);
        Debug.Log(root.General[0].nameweapon);

        //return new CubesData();
    }
}
