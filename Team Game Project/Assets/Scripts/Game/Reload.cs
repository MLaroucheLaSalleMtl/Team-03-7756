using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] private GameObject prefabProjectile;
    [SerializeField] private GameObject reloadPosition;
    private bool isArmed = false;

    public void OnMouseDown()
    {
        if (!isArmed)
        {
            isArmed = true;
            Instantiate(prefabProjectile, reloadPosition.transform.position, reloadPosition.transform.rotation);
            prefabProjectile.GetComponent<Rigidbody2D>().simulated = false;
            Destroy(gameObject);
        }
    }
}
