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
        diText.text = damage.ToString(); // 데미지는 무조건 음수로 표기해서 렌더링
        diText.gameObject.SetActive(true);
    }

    [SerializeField]
    TextMeshProUGUI scoreText;
}
