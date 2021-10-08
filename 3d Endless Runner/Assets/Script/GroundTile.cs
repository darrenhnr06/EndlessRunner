using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GameObject groundSpawnerGameObject;
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawnerGameObject = GameObject.Find("GroundSpawner");
        groundSpawner = groundSpawnerGameObject.GetComponent<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
}
