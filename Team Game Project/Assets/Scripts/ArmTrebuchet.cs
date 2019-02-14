using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrebuchet : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "sling")
        {
            Debug.Log("Collided!");
            gameObject.transform.position = col.gameObject.transform.position;
        }
    }
}
