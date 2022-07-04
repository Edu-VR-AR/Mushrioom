using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeBetweenSpawn = 2.0f;
    [SerializeField] public Transform _path;

    private SpawnPoint[] _spawnPoints;
    private float _spawnTimeDecimator = 1.01f;

    private void Awake()
    {
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(CreateNewEnemy());
    }

    private IEnumerator CreateNewEnemy()
    {
        bool isInWork = true;

        while (isInWork)
        {
            WaitForSeconds timeDelay = new WaitForSeconds(_timeBetweenSpawn);

            Transform transform = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform;
            Enemy newEnemy = Instantiate(_enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<WaypointMovement>()._path = _path;

            yield return timeDelay;

            _timeBetweenSpawn = _timeBetweenSpawn / _spawnTimeDecimator;
        }
    }
}
