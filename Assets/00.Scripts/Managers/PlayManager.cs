using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isGameOver = false;
        score = 0;
        prevTime = Time.time;

        #region Valid Check
        if (itemShieldMinTime > itemShieldMaxTime)
            Algorithm.Swap(ref itemShieldMinTime, ref itemShieldMaxTime);
        #endregion

        for (int i = 0; i < GeneralManager.instance.curLevelSetting.spawnerCount; i++)
            Instantiate(
                bulletSpawnerPrefabs[Random.Range(0, bulletSpawnerPrefabs.Length)],
                new Vector3(Random.Range(-Stage.instance.mapInnerSideHalfLength, Stage.instance.mapInnerSideHalfLength),  // x
                            1f,                                                                                           // y
                            Random.Range(-Stage.instance.mapInnerSideHalfLength, Stage.instance.mapInnerSideHalfLength)), // z
                Quaternion.identity,
                Stage.instance.bulletSpawners.transform
            );
        StartCoroutine(_MakeItemShield());
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (Time.time - prevTime >= 0.1f)
            {
                AddScore(GeneralManager.instance.curLevelSetting.scoreMultiplier);
                prevTime = Time.time;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneName.LOBBY);
        }
    }

    public void AddScore(int score)
    {
        this.score = Mathf.Max(this.score + score, 0);
        MainCanvas.instance.score.UpdateScoreText(this.score);
    }

    public void GameEnd()
    {
        isGameOver = true;
        PlayerPrefs.SetInt(PlayerPrefsKey.BEST_SCORE, Mathf.Max(score, PlayerPrefs.GetInt(PlayerPrefsKey.BEST_SCORE)));
        MainCanvas.instance.gameOver.gameObject.SetActive(true); // ���� ���� ���� ������Ʈ Ȱ��ȭ
    }

    IEnumerator _MakeItemShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(itemShieldMinTime, itemShieldMaxTime));
            var itemShield = ObjectPool.instance.GetItemShield();
            itemShield.transform.position = new Vector3(
                Random.Range(-Stage.instance.mapInnerSideHalfLength + 4f, Stage.instance.mapInnerSideHalfLength - 4f),
                1f,
                Random.Range(-Stage.instance.mapInnerSideHalfLength + 4f, Stage.instance.mapInnerSideHalfLength - 4f)
            );
            itemShield.gameObject.SetActive(true);
        }
    }

    public static PlayManager instance;
    [Header("���� ���� ����")]
    public bool isGameOver;
    [Header("�Ҹ� ������")]
    public BulletSpawner[] bulletSpawnerPrefabs;
    [Header("���� ���� ����")]
    public int score;
    [Header("������ ����")]
    public float itemShieldMinTime;
    public float itemShieldMaxTime;

    float prevTime;
}
