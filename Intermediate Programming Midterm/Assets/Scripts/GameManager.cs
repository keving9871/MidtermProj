using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will randomly generate obstacles for the player to avoid

public class GameManager : MonoBehaviour
{
    public GameObject obstacles;
    public Transform Max, Min;
    public int obstacleCount;
   
    
    void Start()
    {
        //float randomPosX;
        //float randomPosZ;
        //randomPosX = Random.Range(Max.transform.position.x, Min.transform.position.x) + Min.transform.position.x;
        //randomPosZ = Random.Range(Max.transform.position.z, Min.transform.position.z) + Min.transform.position.z;
        //Vector3 randomSpawnPoint = new Vector3(randomPosX, .90f, randomPosZ);

        //Instantiate(obstacles, randomSpawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Awake()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float randomPosX;
            float randomPosZ;
            randomPosX = Random.Range(Max.transform.position.x, Min.transform.position.x);// + Min.transform.position.x;
            randomPosZ = Random.Range(Max.transform.position.z, Min.transform.position.z);// + Min.transform.position.z;
            Vector3 randomSpawnPoint = new Vector3(randomPosX, 1, randomPosZ);
            Instantiate(obstacles, randomSpawnPoint, Quaternion.identity);
        }
    }
}
