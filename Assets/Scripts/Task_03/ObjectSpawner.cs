using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabList;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnRange;

    [SerializeField] private bool _spawnFirstImmidiately;

    private Transform _spawnPoint;
    private float _timeSinceLastSpawn;

    private void Start()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        _timeSinceLastSpawn = _spawnFirstImmidiately ? _spawnInterval : 0f;
    }

    private void Update()
    {
        if (_timeSinceLastSpawn >= _spawnInterval)
        {
            _timeSinceLastSpawn = 0f;
            SpawnObject();
        }
        _timeSinceLastSpawn += Time.deltaTime;
    }

    private void SpawnObject()
    {
        Instantiate(_prefabList[Random.Range(0, _prefabList.Count)], DetermineSpwanPoint(), Quaternion.identity, null);
    }

    private Vector3 DetermineSpwanPoint()
    {
        float xPos = Random.Range(_spawnPoint.position.x - _spawnRange, _spawnPoint.position.x + _spawnRange);
        float zPos = Random.Range(_spawnPoint.position.z - _spawnRange, _spawnPoint.position.z + _spawnRange);
        Vector3 spawnPoint = new Vector3(xPos, _spawnPoint.position.y, zPos);
        return spawnPoint;
    }
}
