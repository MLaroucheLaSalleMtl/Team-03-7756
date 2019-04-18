using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private Animator animator;

    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            Destroy(gameObject);
            // Instantiate projectile at loading position
            Instantiate(projectile, new Vector3(-3, 1.25f, 0), Quaternion.Euler(0, 0, 0));
        }
    }
}
