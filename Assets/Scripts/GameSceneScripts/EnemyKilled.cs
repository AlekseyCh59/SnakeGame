using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    public TMP_Text kill;
    private int killed= 0;
    // Start is called before the first frame update
    private void Awake()
    {
     //   GlobalEventManager.OnEnemyKilled.AddListener(EnemyKill);
    }


}
