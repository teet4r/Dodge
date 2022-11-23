using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{
    void Awake()
    {
        SetGameLevel();
    }

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }

    public void SetGameLevel()
    {
        GeneralManager.instance.gameLevel = levelDropdown.value;
    }

    public Button settingButton;
    public GameObject settingPanel;
    public TMP_Dropdown levelDropdown;
    public Button closeButton;
}
