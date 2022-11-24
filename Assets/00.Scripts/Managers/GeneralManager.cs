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

        RegisterPlayerPrefs();
    }

    void RegisterPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsKey.REGISTERED))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey.REGISTERED, 1);
            PlayerPrefs.SetInt(PlayerPrefsKey.BEST_SCORE, 0);
            PlayerPrefs.SetInt(PlayerPrefsKey.LEVEL, 0);
        }
    }

    public static GeneralManager instance = null;
    public LevelSetting[] levels;
    public LevelSetting curLevelSetting { get { return levels[LobbyCanvas.instance.setting.levelDropdown.dropdown.value]; } }
}
