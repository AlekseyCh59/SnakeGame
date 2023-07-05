using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Expiriens", menuName = "MyScriptable/MyExpiriens", order = 51)]
public class Expiriens : ScriptableObject
{
    [SerializeField] public float expiriens;
    public Sprite sprite;
    public int level;


}
