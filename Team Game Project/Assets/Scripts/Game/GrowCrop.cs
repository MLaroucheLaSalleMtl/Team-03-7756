using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCrop : MonoBehaviour
{
    [SerializeField] private GameObject prefabProjectile;
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Seed")
        {
            Debug.Log("Collided!");
            Destroy(col.gameObject);
            InstantiateProjectile(prefabProjectile);
        }
    }

    public void InstantiateProjectile(GameObject projectile)
    {
        Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        projectile.GetComponent<Animation>().Play("grow");
        projectile.GetComponent<Animation>().PlayQueued("done", QueueMode.CompleteOthers);
    }
}
