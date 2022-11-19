using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosionEffect : MonoBehaviour, IReturnable
{
    void OnEnable()
    {
        StartCoroutine(Return());
    }

    public IEnumerator Return()
    {
        yield return new WaitForSeconds(m_returnTime);
        ObjectPool.instance.ReturnBigExplosionEffect(this);
    }

    public float returnTime
    {
        get { return m_returnTime; }
        set { m_returnTime = value; }
    }

    [SerializeField]
    float m_returnTime;
}
