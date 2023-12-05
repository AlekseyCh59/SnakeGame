using UnityEngine;

public class Move : MonoBehaviour
{
    PlayerManager playerStats;
    string key = "up";
    Rigidbody2D PhisycsBody;
    [SerializeField] Sprite[] SpriteHead = new Sprite[3];
    SpriteRenderer RenderHead;
    private void Awake()
    {
        playerStats = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        RenderHead = GetComponent<SpriteRenderer>();
        PhisycsBody = GetComponent<Rigidbody2D>();
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
            case "up": PhisycsBody.MovePosition(transform.position + Vector3.up * playerStats.speed * Time.fixedDeltaTime); break;
            case "down": PhisycsBody.MovePosition(transform.position + Vector3.down * playerStats.speed * Time.fixedDeltaTime); break;
            case "right": PhisycsBody.MovePosition(transform.position + Vector3.right * playerStats.speed * Time.fixedDeltaTime); break;
            case "left": PhisycsBody.MovePosition(transform.position + Vector3.left * playerStats.speed * Time.fixedDeltaTime); break;

        }
    }

    private void Update()
    {
        switch (key)
        {
            case "up": RenderHead.sprite = SpriteHead[0]; break;
            case "down": RenderHead.sprite = SpriteHead[1]; break;
            case "right": RenderHead.sprite = SpriteHead[2]; RenderHead.flipX = false; break;
            case "left": RenderHead.sprite = SpriteHead[2]; RenderHead.flipX = true; break;

        }
    }
}