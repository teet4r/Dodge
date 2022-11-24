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
        // �ڽ� ���� ���� ������Ʈ
        curHp = 0;
        isAlive = false;
        UpdateBodyColor();

        // �ٸ� Ŭ���� �Լ� ȣ��
        PlayManager.instance.GameEnd();
        Camera.main.transform.parent = Stage.instance.transform; // ī�޶� �÷��̾�� �޷��ֱ� ������ ��Ȱ��ȭ ��Ű�� ���� �̸� ī�޶��� �θ� �缳��

        // �ڽ� ��Ȱ��ȭ
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

    [Header("���� ����")]
    public bool isAlive;

    [Header("�ڵ� ȸ�� ����")]
    public int autoHealAmount;
    public float autoHealIntervalTime;

    Rigidbody m_rigidbody;
    Renderer m_renderer;
    Color m_color;
    float autoHealPrevTime;
}
