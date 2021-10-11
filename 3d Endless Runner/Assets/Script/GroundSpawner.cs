using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject groundTile;

    private Vector3 nextSpawnPoint;

    private GameObject temp;
  
    private void Awake()
    {
        PlayerPrefs.SetInt("Obstacle", 2);
    }

    public void SpawnTile()
    {
       temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public void ChangeTilePos()
    {
        temp.transform.position = nextSpawnPoint;
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        
         for (int i = 0; i < temp.transform.GetChild(2).transform.childCount; i++)
        {
            temp.transform.GetChild(2).transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 1; i < PlayerPrefs.GetInt("Obstacle") + 1 ; i++)
        {
            temp.transform.GetChild(3).transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = PlayerPrefs.GetInt("Obstacle") + 1; i < 3; i++)
        {
            temp.transform.GetChild(3).transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void Start()
    {
       SpawnTile();
    }
}
