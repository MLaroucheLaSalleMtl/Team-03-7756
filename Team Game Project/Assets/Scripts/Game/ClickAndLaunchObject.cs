using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=QM8M0RainRI

public class ClickAndLaunchObject : MonoBehaviour
{
    private float releaseDelay = 0.1f;
    private bool isBeingDragged = false;

    private void Update()
    {
        if (isBeingDragged)
        {
            BroadcastMessage("OnMouseDrag");
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
        StartCoroutine(Release()); 
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        if (GetComponent<SpringJoint2D>().breakForce >= 50000.0f)
        {
            GetComponent<SpringJoint2D>().enabled = false;
            this.enabled = false;
        }
    }
}
