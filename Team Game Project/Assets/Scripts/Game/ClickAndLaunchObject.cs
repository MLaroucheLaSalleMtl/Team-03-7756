using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=QM8M0RainRI

public class ClickAndLaunchObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private float releaseDelay = 0.1f;
    private bool isBeingDragged = true;
    private ArmWeapon weapon;

    private void Awake()
    {
        weapon = FindObjectOfType<ArmWeapon>();
    }

    private void Update()
    {
        if (!isBeingDragged)
        {
            //Launch();
            StartCoroutine(Release());
        }
    }

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        if (weapon.isArmed)
        {
            isBeingDragged = true;
        }
    }

    public void OnMouseUp()
    {
        isBeingDragged = false;
        //GetComponent<Rigidbody2D>().isKinematic = false;
        //StartCoroutine(Release()); 
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
        //GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        //GetComponent<Rigidbody2D>().drag = 0.1f;
        //GetComponent<Rigidbody2D>().angularDrag = 0.2f;
        //GetComponent<Rigidbody2D>().simulated = true;
        weapon.isArmed = false;
    }


    /// <summary>
    /// 
    /// After launching, the player should not be allowed to pick it up again.
    /// </summary>
    public void Launch()
    {
        //GetComponent<SpringJoint2D>().connectedBody = null;
        GetComponent<SpringJoint2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = true;
        weapon.isArmed = false;
    }
}
