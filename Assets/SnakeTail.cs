using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeTail : Player
{
    [SerializeField] public Transform Tail;
    [SerializeField]private Transform SnakeHead;
    [SerializeField] private float CircleDiameter;
    [SerializeField] private int SnakeLength=3;
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    private void Awake()
    {
        positions.Add(SnakeHead.position);

    }

    private void Start()
    {
        for (int i = 0; i < SnakeLength; i++) AddCircle();
    }
    private void Update()
    {
        float distance = ((Vector2)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Ќаправление от старого положени€ головы, к новому
            Vector2 direction = ((Vector2)SnakeHead.position - positions[0]);

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }
        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);

        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, transform);
        //circle.GetComponent<Move>().enabled = false;
        //circle.GetComponent<Player>().enabled = false;
        //circle.GetComponent<Eating>().enabled = false;
        //circle.GetComponent<CircleCollider2D>().isTrigger = true;
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        if (snakeCircles.Count > 2) { 
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
    }
    }
}