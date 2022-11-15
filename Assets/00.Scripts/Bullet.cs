using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IReturnable
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rb.velocity = transform.forward * speed;

        StartCoroutine(Return());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag.PLAYER))
        {
            collision.gameObject.GetComponent<Player>().GetDamage((int)rb.velocity.magnitude);
            ObjectPool.instance.ReturnBullet(this);
        }
        else if (collision.gameObject.CompareTag(Tag.WALL))
            ObjectPool.instance.ReturnBullet(this);
    }

    public IEnumerator Return()
    {
        yield return new WaitForSeconds(m_returnTime);
        ObjectPool.instance.ReturnBullet(this);
    }

    public float speed;
    public float returnTime
    {
        get { return m_returnTime; }
        set { m_returnTime = value; }
    }

    [SerializeField]
    float m_returnTime;

    Rigidbody rb;
}