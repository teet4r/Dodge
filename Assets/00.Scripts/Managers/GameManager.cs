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
                Quaternion.identity
            );

        StartCoroutine(_ScoreUpdate());
    }

    public void AddScore(int score)
    {
        this.score = Mathf.Max(this.score + score, 0);
    }

    IEnumerator _ScoreUpdate()
    {
        while (!isGameOver)
        {
            AddScore(scoreMultiplier);
            MainCanvas.instance.score.UpdateScoreText(score);
            yield return new WaitForSeconds(1f / Mathf.Max(scorePerSecond, 1f));
        }
    }

    public static GameManager instance;
    [Header("���� ���� ����")]
    public bool isGameOver;
    [Header("�Ҹ� ������")]
    public BulletSpawner bulletSpawnerPrefab;
    public int bulletSpawnerCount;
    [Header("���� ���� ����")]
    [Tooltip("���� ��� ��")]
    public int scoreMultiplier;
    [Tooltip("�ʴ� scoreMultiplier ȹ��")]
    public int scorePerSecond;

    int score;
}
