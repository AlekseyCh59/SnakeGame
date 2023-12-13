using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : MonoBehaviour
{
    Rigidbody2D sphere;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.OverlapCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
