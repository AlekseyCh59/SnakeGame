using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeTail : MonoBehaviour
{

    [SerializeField] public GameObject Tail;
    //[SerializeField] protected Transform SnakeHead;
    [SerializeField] private float CircleDiameter;
    //private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    GameScript gameManager;
    Spawner spawner;
    //массив картинок и Рендеров
    Vector2 dir;
    [SerializeField] Sprite[] SpriteTail = new Sprite[6];
    List<SpriteRenderer> RenderTail = new();
    private void Awake()
    {
        GlobalEventManager.OnPlayerLevelUp.AddListener(AddCircle);
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        gameManager.SnakeList.Add(gameObject);
    }

    private void Start()
    {
        
        positions.Add(transform.position);
        AddCircle();
    }
    private void Update()
    {
        float distance = ((Vector2)gameManager.SnakeList[0].transform.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector2 direction = ((Vector2)gameManager.SnakeList[0].transform.position - positions[0]);

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }
        for (int i = 1; i < gameManager.SnakeList.Count; i++)
        {
            gameManager.SnakeList[i].transform.position = Vector2.Lerp(positions[i], positions[i-1], distance / CircleDiameter);
            gameManager.SnakeList[i].transform.position = new Vector3(gameManager.SnakeList[i].transform.position.x,
                                                                        gameManager.SnakeList[i].transform.position.y,
                                                                        gameManager.SnakeList[i - 1].transform.position.z - gameManager.SnakeList[i].transform.position.z);
            gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[0];
            //RenderTail[i].sprite = SpriteTail[0];
            dir = positions[i] - positions[i - 1];
            dir.Normalize();
            if (dir.x > 0.5f)
            {
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[2];
                RenderTail[i].flipX = false;
            }
            else if (dir.x < -0.5f)
            {
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[2];
                RenderTail[i].flipX = true;
            } 
            else if (dir.y > 0.5f)
            {
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[0];
            } 
            else if (dir.y < -0.5f)
            {
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[1];
            }
        }
    }

    public void AddCircle()
    {
        GameObject circle = spawner.UniSpawn(Tail, positions[^1]);
        gameManager.SnakeList.Add(circle);
        positions.Add(circle.transform.position);
        //RenderTail.Add(circle.GetComponent<SpriteRenderer>());
    }
}