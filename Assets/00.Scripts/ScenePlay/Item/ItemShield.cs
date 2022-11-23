using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(SphereCollider))]
public class ItemShield : MonoBehaviour
{
    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_sphereCollider = GetComponent<SphereCollider>();
        m_originColor = m_renderer.material.color;
    }

    void OnEnable()
    {
        #region Valid Check
        if (destroyMinTime > destroyMaxTime)
            Algorithm.Swap(ref destroyMinTime, ref destroyMaxTime);
        #endregion

        m_renderer.material.color = m_originColor;
        StartCoroutine(_Blinking());
        StartCoroutine(_Destroy());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.PLAYER))
            ObjectPool.instance.ReturnItemShield(this);
    }

    IEnumerator _Blinking()
    {
        while (true)
        {
            for (float a = 0f; a <= 1f; a += 0.01f)
            {
                m_renderer.material.color = new Color(m_originColor.r, m_originColor.g, m_originColor.b, a);
                yield return null;
            }
            for (float a = 1f; a >= 0f; a -= 0.01f)
            {
                m_renderer.material.color = new Color(m_originColor.r, m_originColor.g, m_originColor.b, a);
                yield return null;
            }
        }
    }

    IEnumerator _Destroy()
    {
        float destroyTime = Random.Range(destroyMinTime, destroyMaxTime);
        yield return new WaitForSeconds(destroyTime);
        ObjectPool.instance.ReturnItemShield(this);
    }

    public float destroyMinTime;
    public float destroyMaxTime;

    Renderer m_renderer;
    SphereCollider m_sphereCollider;
    Color m_originColor;
}
