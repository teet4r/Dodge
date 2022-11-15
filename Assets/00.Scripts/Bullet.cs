using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rb.velocity = transform.forward * speed;
        ObjectPool.instance.ReturnBullet(this, returnTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag.PLAYER))
            collision.gameObject.GetComponent<Player>().Die();
    }

    public float speed;
    public float returnTime;

    Rigidbody rb;
}