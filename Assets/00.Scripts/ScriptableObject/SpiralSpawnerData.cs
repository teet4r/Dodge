using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiralSpawnerData", menuName = "ScriptableObject/SpiralSpawnerData")]
public class SpiralSpawnerData : ScriptableObject
{
    [Tooltip("�Ѿ� ������ ����")]
    public float angle;
    [Tooltip("�߻� ����")]
    public int spawnCount;
    [Tooltip("�� ���� �Ѿ��� ��� �߻�ǰ� ���� �߻������ ����")]
    public float spawnRate;
    [Tooltip("���� ������ �Ѿ��� �߻�Ǳ������ ����")]
    public float spawnInterval;
}
