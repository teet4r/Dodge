using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    void OnEnable()
    {
        bestScoreText.text = "Best Score: " + GameManager.instance.score.ToString();
    }

    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;
}
