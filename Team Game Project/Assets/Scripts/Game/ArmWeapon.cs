using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballistaAnchor;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Debug.Log("Collided!");

            //Activate the Spring Joint 2D on projectile and attach it to the anchor
            col.gameObject.GetComponent<SpringJoint2D>().enabled = true;
            col.gameObject.GetComponent<SpringJoint2D>().connectedBody = ballistaAnchor;

            //Disable gravity on projectile
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
    }
}
