using TMPro;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;

    public int Length = 1;


    private SnakeTail componentSnakeTail;

    private Vector2 touchLastPos;
    private float sidewaysSpeed;

    private void Start()
    {

        componentSnakeTail = GetComponent<SnakeTail>();

        for (int i = 0; i < Length; i++) componentSnakeTail.AddCircle();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            componentSnakeTail.AddCircle();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            componentSnakeTail.RemoveCircle();
        }

    }

    private void FixedUpdate()
    {
       if (Input.GetKey(KeyCode.UpArrow))
        {
            Sensitivity = ForwardSpeed * Time.deltaTime;
            transform.Translate(0, Sensitivity, 0);
        }

    }
}