using System.Threading.Tasks;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    Rigidbody2D rbEnemy;
    Vector3 Direct;
    public float currentHp { get; private set; }
    public Transform exp;
    public GameScript gameScript; //PUBLIC?!
    Spawner spawner;


    private void Awake()
    {

        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }


    private void Start()
    {
        PlayerPos = gameScript.SnakeList[0];
        currentHp = gameScript.enemyStats.maxhp;
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        gameScript.clearEnemy(this.gameObject);
    }

    private void OnEnable()
    {
        currentHp = gameScript.enemyStats.maxhp;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("weapon"))
        {
            currentHp -= 2;
            if (currentHp <= 0)
            {
                spawner.UniSpawn(exp, this.transform.position);
                gameScript.clearEnemy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        if (this.gameObject)
        {
            Waiting();
            Direct = PlayerPos.position - transform.position;
            Direct.Normalize();
            rbEnemy.MovePosition(transform.position + Direct * gameScript.enemyStats.Speed * Time.deltaTime);

        }
    }



    async void Waiting()
    {

        float min = (gameScript.SnakeList[0].position - this.transform.position).magnitude;
        foreach (var item in gameScript.SnakeList)
        {
            float distance = (item.position - this.transform.position).magnitude;
            if (min > distance)
            {
                min = distance;
                PlayerPos = item;
            }
        }
        await Task.Delay(1000);

    }

    private void FixedUpdate() //SOME SHIT HERE
    {


       
    }
}
