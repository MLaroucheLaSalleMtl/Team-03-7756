using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject target;
    [SerializeField] private float speed = 1;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("EnemyTarget");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * speed);
    }
}

