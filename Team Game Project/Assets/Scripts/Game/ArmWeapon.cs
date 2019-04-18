using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    public GameObject load;
    private Animator animator;

    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        load = gameObject.GetComponent<GameObject>();
        load.gameObject.tag = "Load Position";
    }

    public void OnMouseDown()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            Destroy(gameObject);
            // Instantiate projectile at loading position
            Instantiate(projectile, new Vector3(load.transform.position.x, load.transform.position.y), Quaternion.Euler(0, 0, 0));
        }
    }
}
