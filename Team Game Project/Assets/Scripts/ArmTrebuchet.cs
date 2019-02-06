using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrebuchet : MonoBehaviour
{
    public void Update(Collider2D col)
    {
        if (gameObject.transform.position == col.transform.position)
        {
            gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
    }

    public void OnCollisionEnter(Collider2D col)
    {
        if (col.name == "sling_2")
        {
            gameObject.transform.position = col.transform.position;
        }
    }
}
