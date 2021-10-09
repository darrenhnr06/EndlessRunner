using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    private void Awake()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
  
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.ChangeTilePos();
    }
}
