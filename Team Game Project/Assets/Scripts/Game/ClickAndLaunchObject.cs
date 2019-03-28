using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=QM8M0RainRI

public class ClickAndLaunchObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector2 prevVelocity;

    private float releaseDelay = 0.1f;
    private bool isBeingDragged = true;
    private ArmWeapon weapon;

    private void Awake()
    {
        weapon = FindObjectOfType<ArmWeapon>();
    }

    private void Update()
    {
        if(GetComponent<SpringJoint2D>() != null) //if the spring joint exists
        {
            if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                weapon.isArmed = false;
                Destroy(GetComponent<SpringJoint2D>());
                GetComponent<Rigidbody2D>().velocity = prevVelocity;
            }
            if(!isBeingDragged)
            {
                prevVelocity = GetComponent<Rigidbody2D>().velocity;
            }
        }
    }

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        GetComponent<SpringJoint2D>().enabled = false;

        if (weapon.isArmed)
        {
            isBeingDragged = true;
        }
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnMouseUp()
    {
        GetComponent<SpringJoint2D>().enabled = true;
        isBeingDragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false; 
    }

    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        GetComponent<SpringJoint2D>().enabled = false;
        GetComponent<SpringJoint2D>().connectedBody = null;
        weapon.isArmed = false;
    }
}
