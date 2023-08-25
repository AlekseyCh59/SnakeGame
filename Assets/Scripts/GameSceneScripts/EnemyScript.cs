using System.Threading.Tasks;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    Rigidbody2D rbEnemy;
    Vector3 Direct;
    public float currentHp { get; private set; }
    public GameObject exp;
    public GameScript gameScript; //PUBLIC?!
    public EnemyStats enemyStats;
    int cadr = 0;
    ObjectPool objectpool;

    private void Awake()
    {

        gameScript = GameObject.Find("GameManager").GetComponent<GameScript>();
    }


    private void Start()
    {
        objectpool = ObjectPool.Instance;
        PlayerPos = gameScript.SnakeList[0].transform;
        currentHp = enemyStats.maxhp;
        rbEnemy = GetComponent<Rigidbody2D>();
    }


    private void OnDisable()
    {

    }


    private void OnEnable()
    {
        currentHp = enemyStats.maxhp;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("weapon"))
        {
            currentHp -= 5;

            if (currentHp <= 0 && gameObject.activeInHierarchy)
            {
                GlobalEventManager.SendEnemyKilled();
                GameObject obj = objectpool.SpawnFromPool("Exp", gameObject.transform.position, transform.rotation);
                obj.GetComponent<ExpEat>().exp = enemyStats.experiens;
                objectpool.BackToPoll(gameObject);
            }
        } else if (collision.tag.Contains("Player"))
        {
            GlobalEventManager.SendPlayerDamage(enemyStats.damage);//Нужно добавить тип урона врага

        }
    }

    private void Update()
    {
        cadr++;
        if (cadr == 10)
        {
            float min = (gameScript.SnakeList[0].transform.position - this.transform.position).magnitude;
            foreach (var item in gameScript.SnakeList)
            {
                float distance = (item.transform.position - this.transform.position).magnitude;
                if (min > distance)
                {
                    min = distance;
                    PlayerPos = item.transform;
                }
            }
            cadr =0;
        }
        Direct = PlayerPos.position - transform.position;
        Direct.Normalize();
        rbEnemy.MovePosition(transform.position + Direct * enemyStats.speed * Time.deltaTime);


    }

}
