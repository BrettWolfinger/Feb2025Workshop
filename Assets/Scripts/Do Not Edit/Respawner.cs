
using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public float respawnTime;
    public HealthUIText healthUI;

    void OnEnable()
    {
        Health.PlayerDestroyed += RespawnPlayer;
        Health.EnemyDestroyed += RespawnEnemy;
    }

    void OnDisable()
    {
        Health.PlayerDestroyed -= RespawnPlayer;
        Health.EnemyDestroyed -= RespawnEnemy;
    }

    private void RespawnEnemy()
    {
        StartCoroutine(SpawnRoutine(enemyPrefab,transform.position,Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, 180f ) )));
    }

    private void RespawnPlayer()
    {
        StartCoroutine(SpawnRoutine(playerPrefab, new Vector3(-4f,0f,0f),Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, 0.0f ) )));
        

    }

    public IEnumerator SpawnRoutine(GameObject prefab, Vector3 spawnPosition,Quaternion spawnRotation)
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(prefab,spawnPosition, spawnRotation);
        healthUI.ReferencePlayerHealth();
    }
}
