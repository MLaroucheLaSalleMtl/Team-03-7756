using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrebuchet : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "sling_2")
        {
            Debug.Log("Collided!");
            gameObject.transform.position = col.gameObject.transform.position;
            gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
    }
}
