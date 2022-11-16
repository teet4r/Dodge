using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isGameOver = false;
        score = 0;

        for (int i = 0; i < bulletSpawnerCount; i++)
            Instantiate(
                bulletSpawnerPrefab,
                new Vector3(Random.Range(-Stage.instance.mapSize * 5f + 1f, Stage.instance.mapSize * 5f - 1f),  // x
                            1f,                                                                                 // y
                            Random.Range(-Stage.instance.mapSize * 5f + 1f, Stage.instance.mapSize * 5f - 1f)), // z
                Quaternion.identity,
                parent.transform
            );

        StartCoroutine(_ScoreUpdate());
    }

    public void AddScore(int score)
    {
        this.score = Mathf.Max(this.score + score, 0);
        MainCanvas.instance.score.UpdateScoreText(this.score);
    }

    /// <summary>
    /// 0.1�ʸ��� ���� ���
    /// ���ھ� ������Ʈ�� ����ž� ���� ������ �Ѿ
    /// </summary>
    /// <returns></returns>
    IEnumerator _ScoreUpdate()
    {
        WaitForSeconds wfs = new WaitForSeconds(0.1f);
        while (Player.instance.isAlive)
        {
            AddScore(scoreMultiplier);
            yield return wfs;
        }
    }

    public static GameManager instance;
    [Header("���� ���� ����")]
    public bool isGameOver;
    [Header("�Ҹ� ������")]
    public GameObject parent;
    public BulletSpawner bulletSpawnerPrefab;
    public int bulletSpawnerCount;
    [Header("���� ���� ����")]
    public int score;
    [Tooltip("���� ��� ��")]
    public int scoreMultiplier;
}
