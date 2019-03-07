using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private float releaseDelay = 0.1f;
    private bool isBeingDragged = false;

    private void Update()
    {
        if (isBeingDragged == true)
        {
            GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnMouseDown()
    {
        isBeingDragged = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnMouseUp()
    {
        isBeingDragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

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
