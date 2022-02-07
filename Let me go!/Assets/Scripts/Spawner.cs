using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject Car;
    private float _timeSpawn;

    private void Start()
    {
        _timeSpawn = Random.Range(4f, 10f);
        StartCoroutine(SpawnCD(_timeSpawn));
    }

    private void Repeat()
    {
        _timeSpawn = Random.Range(4f, 10f);
        StartCoroutine(SpawnCD(_timeSpawn));
    }

    private IEnumerator SpawnCD(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(Car, spawnPosition.position, Quaternion.identity);
        Repeat();
    }
}
