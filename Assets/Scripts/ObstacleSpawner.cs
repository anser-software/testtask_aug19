using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _spawnInterval = 1F;
    [SerializeField] private float _ySpawnPosition = 6F;
    [SerializeField] private float _xOffset = 1.5F;
    private float _timer = 0F;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
            return;
        
        _timer += Time.deltaTime;

        if (_timer < _spawnInterval)
            return;

        _timer = 0F;
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        var position = new Vector3(Random.Range(0F, 1F) > 0.5f ? _xOffset : -_xOffset, _ySpawnPosition, 0f);

        Instantiate(_obstaclePrefab, position, Quaternion.identity).transform.parent = transform;
    }

}
