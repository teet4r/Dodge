using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BlinkingText : MonoBehaviour
{
    void Awake()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        m_text.color = new Color(m_text.color.r, m_text.color.g, m_text.color.b, 0f);
    }

    void OnEnable()
    {
        if (m_blinking == null)
            m_blinking = StartCoroutine(_BlinkingText());
    }

    void OnDisable()
    {
        Stop();
    }

    IEnumerator _BlinkingText()
    {
        if (isBlinking) yield break;
        isBlinking = true;
        while (true)
        {
            Debug.Log("여기1 " + Time.time);
            for (float i = 0f; i <= 1f; i += 0.02f)
            {
                m_text.color = new Color(m_text.color.r, m_text.color.g, m_text.color.b, i);
                yield return new WaitForSeconds(0.01f / blinkingPerSecond);
            }
            for (float i = 1f; i >= 0f; i -= 0.02f)
            {
                m_text.color = new Color(m_text.color.r, m_text.color.g, m_text.color.b, i);
                yield return new WaitForSeconds(0.01f / blinkingPerSecond);
            }
            Debug.Log("여기2 " + Time.time);
        }
    }

    public void Stop()
    {
        StopCoroutine(m_blinking);
        isBlinking = false;
    }

    public bool isBlinking;
    public float blinkingPerSecond;

    TextMeshProUGUI m_text;
    Coroutine m_blinking;
}
