using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < bulletSpawnerCount; i++)
            Instantiate(bulletSpawnerPrefab, new Vector3(Random.Range(-9f, 9f), 1f, Random.Range(-9f, 9f)), Quaternion.identity);
    }

    public BulletSpawner bulletSpawnerPrefab;
    public int bulletSpawnerCount;
}
