using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeTail : MonoBehaviour
{

    [SerializeField] public Transform Tail;
    //[SerializeField] protected Transform SnakeHead;
    [SerializeField] private float CircleDiameter;
    [SerializeField] private int SnakeLength = 3;
    //private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    GameScript gameManager;
    Spawner spawner;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
        gameManager.SnakeList.Add(transform);
        
    }

    private void Start()
    {

        positions.Add(transform.position);
        for (int i = 0; i < SnakeLength; i++) AddCircle();
    }
    private void Update()
    {
        float distance = ((Vector2)gameManager.SnakeList[0].position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Íàïðàâëåíèå îò ñòàðîãî ïîëîæåíèÿ ãîëîâû, ê íîâîìó
            Vector2 direction = ((Vector2)gameManager.SnakeList[0].position - positions[0]);

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }
        for (int i = 1; i < gameManager.SnakeList.Count; i++)
        {
             gameManager.SnakeList[i].position = Vector2.Lerp(positions[i], positions[i-1], distance / CircleDiameter);

        }
    }

    public void AddCircle()
    {
        Transform circle = spawner.UniSpawn(Tail, positions[positions.Count - 1]);
        gameManager.SnakeList.Add(circle);
        positions.Add(circle.position);
    }
}