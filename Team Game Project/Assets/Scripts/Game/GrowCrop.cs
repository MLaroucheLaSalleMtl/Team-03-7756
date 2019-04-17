using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCrop : MonoBehaviour
{
    [SerializeField] private GameObject prefabCrop;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Seed")
        {
            Debug.Log("Collided!");
            Destroy(col.gameObject);
            InstantiateProjectile(prefabCrop);
        }
    }

    public void InstantiateProjectile(GameObject projectile)
    {
        Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
    }
}
