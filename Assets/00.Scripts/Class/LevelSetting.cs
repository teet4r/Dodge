using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSetting
{
    public LevelSetting(params int[] args)
    {
        spawnerCount = args[0];
        playerMaxHp = args[1];
        scoreMultiplier = args[2];
        shieldDurability = args[3];
    }

    public int spawnerCount;
    public int playerMaxHp;
    public int scoreMultiplier;
    public int shieldDurability;
}
