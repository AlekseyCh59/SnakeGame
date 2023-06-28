using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameScript : MonoBehaviour
{
    public TMP_Text hp;
    public TMP_Text money;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        hp.text = stats.maxhp + "/" + stats.currentHP.ToString();
        money.text = stats.money.ToString();
    }
}
