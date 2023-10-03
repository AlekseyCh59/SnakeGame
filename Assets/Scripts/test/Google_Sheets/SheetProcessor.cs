using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;
using UnityEditor;
using System.IO;

public class SheetProcessor : MonoBehaviour
{
    public void ProcessData(string cvsRawData)
    {
        cvsRawData = cvsRawData.Replace("\"\"", "\"");
        cvsRawData = cvsRawData.Remove(0, 1);
        cvsRawData = cvsRawData.Remove(cvsRawData.Length - 2, 2);
        //Debug.Log((WeaponStats)JsonUtility.FromJson(cvsRawData, typeof(WeaponStats)));
        Root root = new Root();
        root = JsonConvert.DeserializeObject<Root>(cvsRawData);

        FileStream fileStream = new FileStream(Application.persistentDataPath + "/" + "root.json", FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(cvsRawData);
        }
        
        //return new CubesData();
    }
}
