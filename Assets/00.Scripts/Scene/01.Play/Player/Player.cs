using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    void Awake()
    {
        instance = this;

        m_rigidbody = GetComponent<Rigidbody>();
        m_renderer = GetComponent<Renderer>();
        m_color = m_renderer.material.color;
    }

    void OnEnable()
    {
        curHp = maxHp = GeneralManager.instance.curLevelSetting.playerMaxHp;
        isAlive = true;
        autoHealPrevTime = Time.time;
    }

    void Update()
    {
        m_rigidbody.velocity = (Vector3.forward * Input.GetAxis(Axis.VERTICAL) + Vector3.right * Input.GetAxis(Axis.HORIZONTAL)) * moveSpeed;

        AutoHeal();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.ITEM_SHIELD))
            shield.AddShield(GeneralManager.instance.curLevelSetting.shieldDurability);
    }

    public void GetDamage(int damage)
    {
        curHp -= damage;
        if (curHp <= 0)
            Die();
        else
        {
            PlayManager.instance.AddScore(-damage);
            UpdateBodyColor();
            MainCanvas.instance.score.MakeDamageInfoText(-damage);
        }
    }

    public void Die()
    {
        // 자신 변수 먼저 업데이트
        curHp = 0;
        isAlive = false;
        UpdateBodyColor();

        // 다른 클래스 함수 호출
        PlayManager.instance.GameEnd();
        Camera.main.transform.parent = Stage.instance.transform; // 카메라가 플레이어에게 달려있기 때문에 비활성화 시키기 전에 미리 카메라의 부모를 재설정

        // 자신 비활성화
        gameObject.SetActive(false);
    }

    public void UpdateBodyColor()
    {
        m_renderer.material.color = new Color(m_color.r, (float)curHp / maxHp, (float)curHp / maxHp);
    }

    public void AutoHeal()
    {
        if (Time.time - autoHealPrevTime >= autoHealIntervalTime)
        {
            curHp = Mathf.Min(curHp + autoHealAmount, maxHp);
            UpdateBodyColor();
            autoHealPrevTime = Time.time;
        }
    }

    public static Player instance;
    public float moveSpeed;
    public int maxHp;
    public int curHp;
    public Shield shield;

    [Header("상태 변수")]
    public bool isAlive;

    [Header("자동 회복 변수")]
    public int autoHealAmount;
    public float autoHealIntervalTime;

    Rigidbody m_rigidbody;
    Renderer m_renderer;
    Color m_color;
    float autoHealPrevTime;
}
