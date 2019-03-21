using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Enemy : MonoBehaviour
{
        [SerializeField] private int enemyPoints;
        [SerializeField] private int healthPoints;
        [SerializeField] private float moveSpeed;

    public int HealthPoints { get => healthPoints; set => healthPoints = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public int EnemyPoints { get => enemyPoints; set => enemyPoints = value; }
}

