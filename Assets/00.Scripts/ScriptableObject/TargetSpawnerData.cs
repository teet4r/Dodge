using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetSpawnerData", menuName = "ScriptableObject/TargetSpawnerData")]
public class TargetSpawnerData : ScriptableObject
{
    [Tooltip("���ӻ�� �� ����")]
    public float spawnRate;
    [Tooltip("���ӻ�� ����")]
    public float cfFireCount;
    [Tooltip("���ӻ�� ����")]
    public float cfFireRate;
}
