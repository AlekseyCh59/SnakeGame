using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    string key;
    Rigidbody2D PhisycsBody;
    private void Start()
    {
        PhisycsBody= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
            case "up": PhisycsBody.MovePosition(transform.position + Vector3.up * stats.speed * Time.deltaTime); break;
            case "down": PhisycsBody.MovePosition(transform.position + Vector3.down * stats.speed * Time.deltaTime); break;
            case "right": PhisycsBody.MovePosition(transform.position + Vector3.right * stats.speed * Time.deltaTime); break;
            case "left": PhisycsBody.MovePosition(transform.position + Vector3.left * stats.speed * Time.deltaTime); break;

        }
    }
}