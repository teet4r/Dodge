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

    public void MakeDamageInfoText(int damage)
    {
        var diText = ObjectPool.instance.GetDamageInfoText();
        diText.text = damage.ToString(); // �������� ������ ������ ǥ���ؼ� ������
        diText.gameObject.SetActive(true);
    }

    [SerializeField]
    TextMeshProUGUI scoreText;
}
