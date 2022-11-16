using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_color = m_renderer.material.color;
    }

    void OnEnable()
    {
        StartCoroutine(_Routine());
    }

    IEnumerator _Routine()
    {
        yield return StartCoroutine(_FadeIn());
        StartCoroutine(_Fire());
    }

    IEnumerator _FadeIn()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            m_renderer.material.color = new Color(m_color.r, m_color.g, m_color.b, i);
            yield return null;
        }
    }

    IEnumerator _Fire()
    {
        if (isFiring) yield break;
        isFiring = true;
        while (Player.instance.isAlive)
        {
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
            MakeBullet();
        }
        isFiring = false;
    }

    void MakeBullet()
    {
        var bullet = ObjectPool.instance.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.transform.LookAt(Player.instance.transform);
        bullet.gameObject.SetActive(true);
    }

    public float spawnRateMin;
    public float spawnRateMax;

    public bool isFiring;

    Renderer m_renderer;
    Color m_color;
}
