using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmWeapon : MonoBehaviour
{
    //[SerializeField] private GameObject projectile;

    private Animation animation;

    public void Awake()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    public void Start()
    {
        animation.Play("Grow");
    }

    public void Update()
    {
        if(!animation.isPlaying)
        {
            OnMouseClick();
        }
    }

    public void OnMouseClick()
    {
        Destroy(gameObject);
    }
}
