using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpreadSpawnerData", menuName = "ScriptableObject/SpreadSpawnerData")]
public class SpreadSpawnerData : ScriptableObject
{
    public float spawnRate;
    public int bulletCountPerShot;
}
