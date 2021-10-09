using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    GameObject temp;


    public void SpawnTile()
    {
       temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public void ChangeTilePos()
    {
        temp.transform.position = nextSpawnPoint;
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    void Start()
    {
       SpawnTile();
    }

}
