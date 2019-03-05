using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d

public class ClickDrag : MonoBehaviour
{
    /// <summary>
    /// To refine
    /// </summary>
    private Vector3 screenPoint;
    private Vector3 offset;
    public Rigidbody2D rigidBody;

    private float releaseDelay = 0.1f;

    private bool dragging = false;

    private void Update()
    {
        if (dragging == true)
        {
            rigidBody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnMouseDown()
    {
        dragging = true;
        rigidBody.isKinematic = true;
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    /// <summary>
    /// Allows for the object to move according to mouse click and drag
    /// </summary>
    /*public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }*/

    public void OnMouseUp()
    {
        dragging = false;
        rigidBody.isKinematic = false;

        StartCoroutine(
            
            Release()
            
            ); 
    }

    IEnumerator Release ()
    {
        yield return new WaitForSeconds(releaseDelay);

        GetComponent<SpringJoint2D>().enabled = false;
    }
}
