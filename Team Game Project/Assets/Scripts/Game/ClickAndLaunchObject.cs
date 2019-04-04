using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=QM8M0RainRI

public class ClickAndLaunchObject : MonoBehaviour
{
    private float releaseDelay = 0.1f;
    private bool isBeingDragged = false;
    private ArmWeapon weapon;

    //private Vector2 prevVelocity;

    private void Awake()
    {
        weapon = FindObjectOfType<ArmWeapon>();
    }

    private void FixedUpdate()
    {
        if (isBeingDragged)
        {
            GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (weapon.isArmed && isBeingDragged)
        {
            StartCoroutine(LaunchProjectile());
        }

        //if(GetComponent<SpringJoint2D>() != null) //if the spring joint exists
        //{
        //    if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
        //    {
        //        weapon.isArmed = false;
        //        Destroy(GetComponent<SpringJoint2D>());
        //        GetComponent<Rigidbody2D>().velocity = prevVelocity;
        //    }
        //    if(!isBeingDragged)
        //    {
        //        prevVelocity = GetComponent<Rigidbody2D>().velocity;
        //    }
        //}
    }

    public void OnMouseDown()
    {
        isBeingDragged = true;
        GetComponent<Rigidbody2D>().isKinematic = true;

        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //GetComponent<SpringJoint2D>().enabled = false;
    }

    public void OnMouseUp()
    {
        isBeingDragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
        //GetComponent<SpringJoint2D>().enabled = true;

        if (GetComponent<SpringJoint2D>() != null)
        {
            StartCoroutine(LaunchProjectile());
        }
    }

    IEnumerator LaunchProjectile()
    {
        yield return new WaitForSeconds(releaseDelay);
        GetComponent<SpringJoint2D>().enabled = false;
        //GetComponent<SpringJoint2D>().connectedBody = null;
        weapon.isArmed = false;
    }
}
