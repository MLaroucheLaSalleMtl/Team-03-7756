using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballistaAnchor;
    [SerializeField] private GameObject loadPosition;
    private bool isArmed = false;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(!isArmed)
        {
            if (col.gameObject.tag == "Projectile")
            {
                isArmed = true;
                Debug.Log("Collided!");

                //Activate the Spring Joint 2D on projectile and attach it to the anchor
                col.gameObject.GetComponent<SpringJoint2D>().enabled = true;
                col.gameObject.GetComponent<SpringJoint2D>().connectedBody = ballistaAnchor;

                //Disable gravity on projectile
                //col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

                //Position projectile at Loading Position
                col.gameObject.transform.position = loadPosition.transform.position;
                col.gameObject.transform.rotation = loadPosition.transform.rotation;
            }
        }
    }


}
