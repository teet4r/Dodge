using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    [SerializeField]
    TextMeshProUGUI scoreText;
}
