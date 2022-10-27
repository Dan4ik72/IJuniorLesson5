using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ruby _spawningRuby;
    
    private List<SpawnPoint> _spawnPoints;
    
    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        var waitForSeconds = new WaitForSeconds(2);

        while (true)
        {
            Spawn();

            yield return waitForSeconds;
        }
    }      

    private void Spawn()
    {
        SpawnPoint spawningPoint = SpawnPointSelect();

        Instantiate(_spawningRuby.gameObject, spawningPoint.transform.position, Quaternion.identity, spawningPoint.transform);       
    }

    private SpawnPoint SpawnPointSelect()
    {
        int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[randomSpawnPointNumber];
    }
}
