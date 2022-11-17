using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum FadeOutDirection
{
    RIGHT, DOWN, LEFT, UP
}

[RequireComponent(typeof(TextMeshProUGUI))]
public class FadeOutTowardText : MonoBehaviour
{
    void Awake()
    {
        m_text = GetComponent<TextMeshProUGUI>();

        originPosition = transform.position;
        m_dir = (int)direction;
    }

    void OnEnable()
    {
        transform.position = originPosition;

        StartCoroutine(_FadeOutToward());
    }

    IEnumerator _FadeOutToward()
    {
        for (float i = 1f; i >= 0f; i -= 0.005f)
        {
            transform.position = new Vector3(
                transform.position.x + dx[m_dir] * fadeDeltaLength * Time.deltaTime,
                transform.position.y + dy[m_dir] * fadeDeltaLength * Time.deltaTime,
                transform.position.z
            );
            m_text.color = new Color(m_text.color.r, m_text.color.g, m_text.color.b, i);
            yield return null;
        }
        ObjectPool.instance.ReturnDamageInfoText(m_text);
    }

    public FadeOutDirection direction;
    [Tooltip("화면 상에 렌더링하는 거리")]
    public float fadeDeltaLength;

    int[] dx = { 1, 0, -1, 0 };
    int[] dy = { 0, -1, 0, 1 };
    int m_dir;
    TextMeshProUGUI m_text;
    Vector3 originPosition;
}
