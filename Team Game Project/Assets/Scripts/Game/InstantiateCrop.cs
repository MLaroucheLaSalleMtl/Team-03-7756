using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCrop : MonoBehaviour
{
    [SerializeField] private GameObject[] Crops;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Planteable Area")
        {
            Debug.Log("collided");
            Destroy(gameObject);
            Instantiate(Crops[Random.Range(0, Crops.Length)], collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }
}
