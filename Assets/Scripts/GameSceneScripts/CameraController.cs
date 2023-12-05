using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    
    //Границы
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float toplimit;
    [SerializeField]
    float bottomLimit;

    public int target = 200;

    public void FindPlayer()
    {
        player = GameObject.Find("Head(Clone)").transform;
        transform.position = new Vector3(player.position.x, player.position.y, -20);

    }
    void Awake()
    {
/*        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;*/
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;*/
        if (player == null)
        {
            FindPlayer();
        }
            transform.position = new Vector3(player.position.x, player.position.y, -20);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, toplimit), -20);
    }
}
