using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Root", menuName = "MyScriptable/MyRoot", order = 51)]
public class Rootscr : ScriptableObject
{
    [SerializeField] public General[] _General = new General[100];
    [SerializeField] public Weapon[] _Weapon = new Weapon[100];
    [SerializeField] public Enemy[] _Enemies = new Enemy[100];
    [SerializeField] public Player[] _Player = new Player[100];
}