using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour
{
    [Header("컴포넌트 가져오기")]
    public Transform PlayerObject;
    public GameObject EnemyObject;

    [Header("변수 관리")]
    public float SpawnTimer = 0f;
    public float SpawnTimer1 = 3f;
    public float SpawnTimer2 = 20f;
    public float SpawnTimerif;
    public bool isSpawn = false; // 현재 스폰중인가
    private float Spawndistance = 15.0f;
    private float FixedPositionY = -3.75f;

    private void Update()
    {
        SpawnTimerRandom();
        EnemySpawn();
    }
    private void SpawnTimerRandom()
    {
        SpawnTimer += Time.deltaTime;

        if (isSpawn == false)
        {
            SpawnTimerif = Random.Range(SpawnTimer1, SpawnTimer2);
            isSpawn = true;
        }
    }
    private void EnemySpawn()
    {
        if (SpawnTimer >= SpawnTimerif)
        {
            Vector2 spawnPosition = PlayerObject.position + PlayerObject.right * Spawndistance;
            spawnPosition.y = FixedPositionY;
            Quaternion spawnRotation = Quaternion.LookRotation(PlayerObject.forward);
            Instantiate(EnemyObject, spawnPosition, spawnRotation);
            SpawnTimer = 0f;
            isSpawn = false;
        }
    }
}
