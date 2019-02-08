using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject player;
    float speed = 2;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * speed);
    }
}

