using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{
    void OnEnable()
    {
        settingPanel.SetActive(false);
    }

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }

    public void LevelDropdownOnValueChanged()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey.LEVEL))
            PlayerPrefs.SetInt(PlayerPrefsKey.LEVEL, levelDropdown.dropdown.value);
    }

    public Button settingButton;
    public GameObject settingPanel;
    public LevelDropdown levelDropdown;
    public Button closeButton;
}
