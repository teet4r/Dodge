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

        m_originColor = m_renderer.material.color;
    }

    void OnEnable()
    {
        ShieldOn(5);
    }

    void Update()
    {
        transform.position = transform.parent.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag.BULLET))
            AddShield(-1);
    }

    /// <summary>
    /// for initialization
    /// </summary>
    /// <param name="initialHitCount"></param>
    void ShieldOn(int initialHitCount)
    {
        if (initialHitCount < 1)
        {
            Debug.Log("인자 제대로 전달해라.");
            return;
        }
        if (isOn) return;
        isOn = true;
        hitCount = initialHitCount;
        m_sphereCollider.enabled = true;
        m_renderer.enabled = true;
        m_renderer.material.color = m_originColor;
    }

    void ShieldOff()
    {
        if (!isOn) return;
        isOn = false;
        hitCount = 0;
        m_sphereCollider.enabled = false;
        m_renderer.enabled = false;
    }

    /// <summary>
    /// using for other classes
    /// </summary>
    /// <param name="hitCount"></param>
    void AddShield(int hitCount)
    {
        if (!isOn)
        {
            ShieldOn(hitCount);
            return;
        }
        else // isOn
        {
            this.hitCount += hitCount;
            if (this.hitCount < 1)
                ShieldOff();
        }
    }

    public bool isOn { get; private set; } = false;
    public int hitCount { get; private set; } = 0;

    SphereCollider m_sphereCollider;
    Renderer m_renderer;
    Color m_originColor;
}
