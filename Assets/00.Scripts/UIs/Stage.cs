using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    void Awake()
    {
        instance = this;

        Initialize();
    }

    void Initialize()
    {
        Vector3 variableScale = Vector3.right * 10 * m_mapSize + Vector3.up * 3 + Vector3.forward;

        m_ground.transform.localScale = (Vector3.right + Vector3.forward) * m_mapSize + Vector3.up;
        // East Wall
        m_walls[0].transform.localPosition = Vector3.right * 5 * m_mapSize + Vector3.up;
        m_walls[0].transform.localScale = variableScale;
        // West Wall
        m_walls[1].transform.position = Vector3.right * -5 * m_mapSize + Vector3.up;
        m_walls[1].transform.localScale = variableScale;
        // North Wall
        m_walls[2].transform.position = Vector3.forward * 5 * m_mapSize + Vector3.up;
        m_walls[2].transform.localScale = variableScale;
        // South Wall
        m_walls[3].transform.position = Vector3.forward * -5 * m_mapSize + Vector3.up;
        m_walls[3].transform.localScale = variableScale;
    }

    public static Stage instance = null;
    public float mapSize { get { return m_mapSize; } }

    [Header("스테이지 크기 변수")]
    [SerializeField]
    float m_mapSize;
    [Header("스테이지 오브젝트")]
    [SerializeField]
    GameObject m_ground;
    [SerializeField]
    GameObject[] m_walls;
}
