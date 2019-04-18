using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    //PROPERTIES
    private Rigidbody2D projectile;
    private SpringJoint2D projectileSpringJoint;
    private Rigidbody2D anchor;

    private bool isBeingDragged;
    private float releaseDelay;
    private float maxDragDistance = 1.5f;

    public ParticleSystem splat;

    private LineRenderer lineRenderer;
    private TrailRenderer trail;


    /// <summary>
    /// Initialize the GameObjects related to the projectile
    /// </summary>
    public void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
        projectileSpringJoint = GetComponent<SpringJoint2D>();
        anchor = projectileSpringJoint.connectedBody;
        lineRenderer = GetComponent<LineRenderer>();
        trail = GetComponent<TrailRenderer>();

        //Set the release delay at the middle of the anchor
        releaseDelay = 1 / (projectileSpringJoint.frequency * 4);

        //Set up the Line and Trail Renderers: they are enabled at only certain conditions
        lineRenderer.enabled = false;
        trail.enabled = false;
    }

    /// <summary>
    /// To update the projectile dragging
    /// </summary>
    public void Update()
    {
        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }

        if (isBeingDragged)
        {
            Dragging();
        }
    }

    public int timesCollided = 0;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(timesCollided >= 1 && projectileSpringJoint.enabled == false) //&& collision.gameObject.tag != "IgnoreWall")
        {
            Instantiate(splat, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            timesCollided++;
        }

        if(gameObject.tag == "Loading Position")
        {
            projectileSpringJoint.connectedBody = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    /// <summary>
    /// When the projectile is being dragged
    /// </summary>
    public void OnMouseDown()
    {
        isBeingDragged = true;
        projectile.isKinematic = true;
        lineRenderer.enabled = true;
    }

    /// <summary>
    /// When the projectile is not being dragged
    /// </summary>
    public void OnMouseUp()
    {
        isBeingDragged = false;
        projectile.isKinematic = false;

        //Projectile gets launched
        StartCoroutine(Launch());
    }

    /// <summary>
    /// The behaviour of the projectile while being dragged
    /// </summary>
    public void Dragging()
    {
        projectile = GetComponent<Rigidbody2D>();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float currentDragDistance = Vector2.Distance(mousePosition, anchor.position);

        //When the dragging distance of the spring joint is too large, follow the mouse's position but lock it at set max dragging distance
        if(currentDragDistance > maxDragDistance)
        {
            Vector2 mouseDirection = (mousePosition - anchor.position).normalized;
            projectile.position = anchor.position + mouseDirection * maxDragDistance;
        }
        else //else, keep following the mouse's position
        {
            projectile.position = mousePosition;
        }
        //Update the line renderer
        SetLineRenderer();
    }

    /// <summary>
    /// Allows the projectile to be launched by disabling its Spring Joint
    /// Disables the line renderer after the launch
    /// </summary>
    /// <returns></returns>
    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(releaseDelay);
        projectileSpringJoint.enabled = false;
        lineRenderer.enabled = false;
    }

    public void SetLineRenderer()
    {
        //Set the two existing positions to follow: projectile and anchor
        Vector3[] positions = new Vector3[2];
        positions[0] = projectile.position;
        positions[1] = anchor.position;
        lineRenderer.SetPositions(positions);
    }
}
