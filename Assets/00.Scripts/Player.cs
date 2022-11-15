using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        isAlive = true;
    }

    void Update()
    {
        rb.velocity = (Vector3.forward * Input.GetAxis(Axis.VERTICAL) + Vector3.right * Input.GetAxis(Axis.HORIZONTAL)) * moveSpeed;
    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }

    public static Player instance;
    public float moveSpeed;

    [Header("상태 변수")]
    public bool isAlive;

    Rigidbody rb;
}
