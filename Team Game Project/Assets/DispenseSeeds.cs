using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseSeeds : MonoBehaviour
{
    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject spawner;

    public void DispenseSeed()
    {
        Instantiate(seed, spawner.transform.position, spawner.transform.rotation);
    }
}
