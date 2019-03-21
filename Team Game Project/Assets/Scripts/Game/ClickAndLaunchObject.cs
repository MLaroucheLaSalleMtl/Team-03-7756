using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/watch?v=QM8M0RainRI

public class ClickAndLaunchObject : MonoBehaviour
{
    private float releaseDelay = 0.1f;
    private bool isBeingDragged = true;
    [SerializeField] private ArmWeapon weapon;

    private void Awake()
    {
        GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        if (!isBeingDragged)
        {
            StartCoroutine(Release());
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
        //GetComponent<Rigidbody2D>().isKinematic = false;
        //StartCoroutine(Release()); 
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        GetComponent<SpringJoint2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = true;
        weapon.isArmed = false;
    }
}
