using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d

public class ClickAndDragObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private float releaseDelay = 0.1f;
    private bool isBeingDragged = false;

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        GetComponent<Rigidbody2D>().isKinematic = true;
        isBeingDragged = true;
    }

    /// <summary>
    /// Allows for the object to move according to mouse click and drag
    /// </summary>
    public void OnMouseDrag()
    {
        if(isBeingDragged)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    public void OnMouseUp()
    {
        isBeingDragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
        if (GetComponent<Rigidbody2D>().isKinematic == false)
        {
        }
            StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);

        GetComponent<SpringJoint2D>().enabled = false;
    }
}
