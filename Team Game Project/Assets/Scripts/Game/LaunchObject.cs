using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    private float releaseTime = 0.1f;
    private bool isClicked = false;
    private ArmWeapon weapon;

    public void Awake()
    {
        weapon = FindObjectOfType<ArmWeapon>();
    }

    public void Update()
    {
        if (isClicked)
        {
            GetComponent<Rigidbody2D>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnMouseDown()
    {
        isClicked = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().simulated = true;
    }

    public void OnMouseUp()
    {
        isClicked = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        weapon.isArmed = false;
    }
}

