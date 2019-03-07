using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 playerPosition;
    public float speed = 2.0f;

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerPosition.z = 0;
            playerPosition.y = 0;
        }
        var vel = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, vel);

        if (playerPosition.x - transform.position.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
