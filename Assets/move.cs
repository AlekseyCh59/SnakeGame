using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    string key;
    Rigidbody2D PhisycsBody;
    private void Start()
    {
        PhisycsBody= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0.1 & key != "down")
            key = "up";
        else if (Input.GetAxis("Vertical") < -0.1 & key != "up")
            key = "down";
        if (Input.GetAxis("Horizontal") > 0.1 & key != "left")
            key = "right";
        else if (Input.GetAxis("Horizontal") < -0.1 & key != "right")
            key = "left";

        switch (key)
        {
            case "up": PhisycsBody.MovePosition(transform.position + Vector3.up * Speed * Time.deltaTime); break;
            case "down": PhisycsBody.MovePosition(transform.position + Vector3.down * Speed * Time.deltaTime); break;
            case "right": PhisycsBody.MovePosition(transform.position + Vector3.right * Speed * Time.deltaTime); break;
            case "left": PhisycsBody.MovePosition(transform.position + Vector3.left * Speed * Time.deltaTime); break;

        }
    }
}