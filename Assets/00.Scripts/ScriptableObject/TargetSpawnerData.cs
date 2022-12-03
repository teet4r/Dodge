using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetSpawnerData", menuName = "ScriptableObject/TargetSpawnerData")]
public class TargetSpawnerData : ScriptableObject
{
    [Tooltip("연속사격 간 간격")]
    public float spawnRate;
    [Tooltip("연속사격 개수")]
    public float cfFireCount;
    [Tooltip("연속사격 간격")]
    public float cfFireRate;
}
