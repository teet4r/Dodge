using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowEffect : MonoBehaviour
{
    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        FindChildren(gameObject);
    }

    void FindChildren(GameObject parent)
    {
        if (parent.TryGetComponent(out Image image))
            images.Add(image);
        else if (parent.TryGetComponent(out TextMeshProUGUI textMeshProUGUI))
            texts.Add(textMeshProUGUI);

        for (int i = 0; i < parent.transform.childCount; i++)
            FindChildren(parent.transform.GetChild(i).gameObject);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        StartCoroutine(_Open());
    }

    public void Close()
    {
        StartCoroutine(_Close());
    }

    IEnumerator _Open()
    {
        for (float a = 0f; a <= 1f; a += deltaTransparentValue)
        {
            for (int i = 0; i < images.Count; i++)
                images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, a);
            for (int i = 0; i < texts.Count; i++)
                texts[i].color = new Color(texts[i].color.r, texts[i].color.g, texts[i].color.b, a);
            yield return null;
        }
    }

    IEnumerator _Close()
    {
        for (float a = 1f; a >= 0f; a -= deltaTransparentValue)
        {
            for (int i = 0; i < images.Count; i++)
                images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, a);
            for (int i = 0; i < texts.Count; i++)
                texts[i].color = new Color(texts[i].color.r, texts[i].color.g, texts[i].color.b, a);
            yield return null;
        }
        gameObject.SetActive(false);
    }

    [Range(0.001f, 0.5f)]
    public float deltaTransparentValue;

    List<Image> images = new List<Image>();
    List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();
}
