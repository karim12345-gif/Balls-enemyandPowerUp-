using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3; //becuase vector3 was wrong for some reason 

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public GameObject powerUpPrefab;

    private float zEnemiesSpawn = 12f; // where the enemies are going to spawn from up and go down 
    private float xSpawnRange = 6.0f; // for the x postion for both power ups and enemies 
    private float ZpowerUpRange = 5.0f; // range for the power ups 
    private float ySpawn = 0.6f;

    private float powerUpSpawnTime = 1.0f; // float repeated rate 
    private float enemySpanwTime = 1.0f; // floa reapteed rate 
    private float startDelay = 1.0f; // float time 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, enemySpanwTime); // this will repeat the enmeis in time 
        InvokeRepeating("SpawnPowerUp",startDelay,powerUpSpawnTime); // will repeat the power ups in 1 second per frame 
    }

    // Update is called once per frame
    void Update()
    {
      
    }



    void SpawnEnemies()
    {
        float random = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemiesPrefab.Length); // this is random range , so we can pick random enimes using the array from 0- whatever based on random

        Vector3 spawnPostion = new Vector3(random,ySpawn,zEnemiesSpawn); // this is the random spawn postion and for x ebtween -6 and 6 , y=0.6 and z = 12 for eneimes

       

        Instantiate(enemiesPrefab[randomIndex], spawnPostion , enemiesPrefab[randomIndex].gameObject.transform.rotation );


    }


    void SpawnPowerUp() {

        float random = Random.Range(-xSpawnRange, xSpawnRange); // the x range 
        float randomZ = Random.Range(-ZpowerUpRange, ZpowerUpRange); // of rhte power up z spawn 
        Vector3 spawnPostion1 = new Vector3(random, ySpawn, randomZ); // this is the random spawn postion and for x ebtween -6 and 6 , y=0.6 and z = 12 for eneimes

        Instantiate(powerUpPrefab, spawnPostion1, powerUpPrefab.gameObject.transform.rotation); 



    }
}
