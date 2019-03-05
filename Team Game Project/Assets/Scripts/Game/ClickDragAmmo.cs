using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d


/*

public class ClickDragAmmo : MonoBehaviour
{
/// <summary>
/// To refine
/// </summary>

private Ray ray;
GameObject balista;

public Rigidbody2D rigidBody;
public SpringJoint2D springJoint;
public float maxDistance = 4.0f;
private bool clicked = false;
private Vector3 screenPoint;
private Vector3 offset;

private void Start()
{
    ray = new Ray(balista.transform.position, Vector3.zero);
}

public void OnMouseDown()
{
    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    clicked = true;
    springJoint.enabled = false;
}

public void OnMouseUp()
{
    rigidBody.isKinematic = false;
    clicked = false;
    springJoint.enabled = true;
}

/// <summary>
/// Allows for the object to move according to mouse click and drag
/// </summary>
public void OnMouseDrag()
{
    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    transform.position = curPosition;

    if ()
}
}
*/

class ClickDragAmmo : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    private bool clicked = false;
    private Vector3 screenPoint;
    private Vector3 offset;

    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        clicked = true;
        rigidBody.isKinematic = true;
    }

    public void OnMouseUp()
    {
        rigidBody.isKinematic = false;
        clicked = false;
    }
}