using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private GameObject prefabLoot;
    private int healthPoints = 100;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * movementSpeed);
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
        healthPoints -= 50;
        if (healthPoints <= 0)
        {
            gameManager.AddPoints();
            Instantiate(prefabLoot, gameObject.transform.position, gameObject.transform.rotation);

            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            Destroy(gameObject, 1.0f);
        }
    }
}

