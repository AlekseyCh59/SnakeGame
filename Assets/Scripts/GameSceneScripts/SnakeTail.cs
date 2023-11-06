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
        GlobalEventManager.OnPlayerLevelUp+=AddCircle;
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        gameManager.SnakeList.Add(gameObject);
    }

    private void Start()
    {
        
        positions.Add(transform.position);
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
            //уменьшение дисстанции между частями тела
            gameManager.SnakeList[i].transform.position = Vector2.Lerp(positions[i], positions[i-1], distance / CircleDiameter);
            
            //RenderTail[i].sprite = SpriteTail[0];
            //Получение направления (dir)
            dir = positions[i] - positions[i - 1];
            dir.Normalize();
            //присвоение каждой части тела своего спрайта
            if (dir.x > 0.5f)
            {
                //лево
                if (i == gameManager.SnakeList.Count - 1)
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[5];
                else
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[2];
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().flipX = true;
                //увеличение координат по Z
                gameManager.SnakeList[i].transform.position = new Vector3(gameManager.SnakeList[i].transform.position.x,
                                                                            gameManager.SnakeList[i].transform.position.y,
                                                                            gameManager.SnakeList[i - 1].transform.position.z + 0.5f);
                //RenderTail[i].flipX = false;
            }
            else if (dir.x < -0.5f)
            {
                //право
                if (i == gameManager.SnakeList.Count - 1)
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[5];
                else
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[2];
                gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().flipX = false;
                //увеличение координат по Z
                gameManager.SnakeList[i].transform.position = new Vector3(gameManager.SnakeList[i].transform.position.x,
                                                                            gameManager.SnakeList[i].transform.position.y,
                                                                            gameManager.SnakeList[i - 1].transform.position.z + 0.5f);
                //RenderTail[i].flipX = true;
            } 
            else if (dir.y > 0.5f)
            {
                //вниз
                if (i == gameManager.SnakeList.Count - 1)
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[4];
                else
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[1];
                //увеличение координат по Z
                gameManager.SnakeList[i].transform.position = new Vector3(gameManager.SnakeList[i].transform.position.x,
                                                                            gameManager.SnakeList[i].transform.position.y,
                                                                            gameManager.SnakeList[i - 1].transform.position.z + 0.5f);
            } 
            else if (dir.y < -0.5f)
            {
                //вверх
                if (i == gameManager.SnakeList.Count - 1)
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[3];
                else
                    gameManager.SnakeList[i].transform.GetComponent<SpriteRenderer>().sprite = SpriteTail[0];
                //уменьшение координат по Z
                gameManager.SnakeList[i].transform.position = new Vector3(gameManager.SnakeList[i].transform.position.x,
                                                                            gameManager.SnakeList[i].transform.position.y,
                                                                            gameManager.SnakeList[i - 1].transform.position.z - 0.5f);
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