using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    #region Bullet
    public Bullet GetBullet()
    {
        if (bulletQ.Count == 0)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            return bullet;
        }
        return bulletQ.Dequeue();
    }

    public void ReturnBullet(Bullet bullet)
    {
        if (bullet == null) return;
        bullet.gameObject.SetActive(false);
        bulletQ.Enqueue(bullet);
    }
    #endregion
    #region DamageInfoText
    public TextMeshProUGUI GetDamageInfoText()
    {
        if (damageInfoTextQ.Count == 0)
        {
            TextMeshProUGUI text = Instantiate(damageInfoTextPrefab, MainCanvas.instance.score.transform);
            text.gameObject.SetActive(false);
            return text;
        }
        return damageInfoTextQ.Dequeue();
    }

    public void ReturnDamageInfoText(TextMeshProUGUI text)
    {
        if (text == null) return;
        text.gameObject.SetActive(false);
        damageInfoTextQ.Enqueue(text);
    }
    #endregion

    public static ObjectPool instance = null;

    [Header("Prefabs")]
    public Bullet bulletPrefab;
    public TextMeshProUGUI damageInfoTextPrefab;

    Queue<Bullet> bulletQ = new Queue<Bullet>();
    Queue<TextMeshProUGUI> damageInfoTextQ = new Queue<TextMeshProUGUI>();
}
