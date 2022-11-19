using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Shield : MonoBehaviour
{
    void Awake()
    {
        m_sphereCollider = GetComponent<SphereCollider>();
        m_renderer = GetComponent<Renderer>();

        m_color = m_renderer.material.color;
    }

    void OnEnable()
    {
        isOn = true;
    }

    void Update()
    {
        transform.position = transform.parent.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag.BULLET))
            GetDamage();
    }

    void GetDamage()
    {
        if (!isOn) return;
        hitCount--;
        if (hitCount <= 0)
        {
            isOn = false;
            m_sphereCollider.enabled = false;
        }
        if (m_hitRoutine != null)
            StopCoroutine(m_hitRoutine);
        m_hitRoutine = StartCoroutine(_GetHitEffect());
    }

    IEnumerator _GetHitEffect()
    {
        for (float i = 0.5f; i >= 0f; i -= 0.01f)
        {
            m_renderer.material.color = new Color(m_color.r, m_color.g, m_color.b, i);
            yield return null;
        }
    }

    public int hitCount;
    public bool isOn;

    SphereCollider m_sphereCollider;
    Renderer m_renderer;
    Color m_color;
    Coroutine m_hitRoutine;
}
