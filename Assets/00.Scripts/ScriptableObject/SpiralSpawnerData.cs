using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiralSpawnerData", menuName = "ScriptableObject/SpiralSpawnerData")]
public class SpiralSpawnerData : ScriptableObject
{
    [Tooltip("총알 사이의 각도")]
    public float angle;
    [Tooltip("발사 개수")]
    public int spawnCount;
    [Tooltip("한 차례 총알이 모두 발사되고 다음 발사까지의 간격")]
    public float spawnRate;
    [Tooltip("다음 각도의 총알이 발사되기까지의 간격")]
    public float spawnInterval;
}
