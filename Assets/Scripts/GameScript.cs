using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameScript : MonoBehaviour
{
    public TMP_Text hp;
    public TMP_Text money;
    public TMP_Text Exp;
    public TMP_Text level;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(stats.maxhp + "/" + stats.currentHP);
    }

    // Update is called once per frame
    void Update()
    {

        hp.text = stats.maxhp + "/" + stats.currentHP;
        Exp.text = stats.expForLevel.ToString() + "/" + stats.experiens.ToString();
        money.text = stats.money.ToString();
        level.text = stats.level.ToString();
    }
}
