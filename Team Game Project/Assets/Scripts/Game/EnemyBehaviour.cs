using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] GameObject target;
    [SerializeField] private GameObject prefabLoot;

    [SerializeField] private int enemyPoints = 25;
    [SerializeField] private int healthPoints = 90;
    [SerializeField] private float moveSpeed = 1.0f;


    //public Enemy enemy;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        //enemy.MoveSpeed = 1.0f;
    }

    public void Attack()
    {
        gameManager.health -= Random.Range(15, 25);
    }

    public void Update()
    {
        //Increase movement speed at score threshold
        if (gameManager.totalPoints <= 100)
        {
            moveSpeed = 1.0f;
            //enemy.MoveSpeed = 1.0f;
        }
        if (gameManager.totalPoints == 200)
        {
            moveSpeed = 1.2f;
            //enemy.MoveSpeed = 1.5f;
        }
        if (gameManager.totalPoints == 300)
        {
            moveSpeed = 1.5f;
            //enemy.MoveSpeed = 2.0f;
        }

        Debug.Log(gameObject.transform.position.x - target.transform.position.x);
        if (gameObject.transform.position.x - target.transform.position.x < 12)
        {
            Attack();
            TakeDamage();
        }

        Move();

       
    }

    public void Move()
    {

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(-1.28f, 1.3f), Time.deltaTime * moveSpeed); //enemy.MoveSpeed);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            TakeDamage();
        }
    }

    private void TakeDamage() //Would make more sense to put damage multiplier to projectiles instead... to modify
    {
        Debug.Log("Damage Taken!");
        //enemy.HealthPoints -= (int)Random.Range(60f, 100f);
        healthPoints -= (int)Random.Range(60f, 100f);
        if (healthPoints <= 0)//enemy.HealthPoints <= 0)
        {
            gameManager.AddPoints();
            Instantiate(prefabLoot, gameObject.transform.position, gameObject.transform.rotation);
            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            Destroy(gameObject, 1.0f);
        }
    }
}

