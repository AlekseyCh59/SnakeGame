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

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameScript>();
        //positions.Add(gameManager.SnakeList[0].transform.position);
        gameManager.SnakeList.Add(transform);
        
    }

    private void Start()
    {

        positions.Add(transform.position);
        Debug.Log(transform.position + " / " + gameManager.SnakeList[0].position);
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
        for (int i = 0; i < gameManager.SnakeList.Count; i++)
        {
             gameManager.SnakeList[i+1].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);

        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, transform);
        gameManager.SnakeList.Add(circle);
        positions.Add(circle.position);
    }

    /*public void RemoveCircle()
    {
        if (snakeCircles.Count > 2)
        {
            Destroy(snakeCircles[0].gameObject);
            snakeCircles.RemoveAt(0);
            positions.RemoveAt(1);
        }
    }*/
}