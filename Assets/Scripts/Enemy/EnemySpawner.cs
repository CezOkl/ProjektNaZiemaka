using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]GameObject enemyPref;
    [SerializeField]float spawnTimer = 5f;


    void Start()
    {
        StartSpawning();
    }


    void Spawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z += 5;
        Instantiate(enemyPref, spawnPos, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("Spawn", spawnTimer, spawnTimer);
    }


    void StopSpawning()
    {
        CancelInvoke();
    }

}
