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
            Instantiate(prefabProjectile, transform.position, transform.rotation);
        }
    }
}
