using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private GameObject prefabLoot;
    private GameManager gameManager;
    Enemy enemy = new Enemy();

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        Move();
        
        //Increase movement speed at score threshold
        if (gameManager.totalPoints == 100)
        {
            enemy.MoveSpeed = 1.0f;
        }
        if (gameManager.totalPoints == 200)
        {
            enemy.MoveSpeed = 1.5f;
        }
        if (gameManager.totalPoints == 300)
        {
            enemy.MoveSpeed = 2.0f;
        }
        
    }

    public void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * enemy.MoveSpeed);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            TakeDamage();
            Destroy(col.gameObject);
        }
    }

    private void TakeDamage() //Would make more sense to put damage multiplier to projectiles instead... to modify
    {
        Debug.Log("Damage Taken!");
        enemy.HealthPoints -= (int)Random.Range(60f, 100f);

        if (enemy.HealthPoints <= 0)
        {
            gameManager.AddPoints();
            Instantiate(prefabLoot, gameObject.transform.position, gameObject.transform.rotation);
            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            Destroy(gameObject, 1.0f);
        }
    }
}

