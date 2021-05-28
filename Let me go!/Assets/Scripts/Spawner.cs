using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform spawnPosition;    
    public GameObject Car;
    private float timeSpawn;
   
    void Start()
    {
        timeSpawn = Random.Range(4f, 10f);
        StartCoroutine(SpawnCD(timeSpawn));
    }

    void Repeat()
    {
        timeSpawn = Random.Range(4f, 10f);
        StartCoroutine(SpawnCD(timeSpawn));
    }

    IEnumerator SpawnCD(float time)
    {
        yield return new WaitForSeconds(time);        
        Instantiate(Car, spawnPosition.position, Quaternion.identity);        
        Repeat();
    }
}
