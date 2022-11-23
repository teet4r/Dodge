using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        levels = new LevelSetting[]
        {
            new LevelSetting(5, 500),    // easy
            new LevelSetting(9, 350),    // normal
            new LevelSetting(13, 200)    // hard
        };
    }

    public static GeneralManager instance = null;
    public LevelSetting[] levels;
    public LevelSetting curLevelSetting { get { return levels[LobbyCanvas.instance.setting.levelDropdown.value]; } }
}
