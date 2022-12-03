using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDropdown : MonoBehaviour
{
    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.value = PlayerPrefs.GetInt(PlayerPrefsKey.LEVEL);


    }

    public TMP_Dropdown dropdown;
}
