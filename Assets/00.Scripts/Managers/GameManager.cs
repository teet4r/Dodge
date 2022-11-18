using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        instance = this;

        if (!PlayerPrefs.HasKey(PlayerPrefsKey.REGISTERED))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey.REGISTERED, 1);
            PlayerPrefs.SetInt(PlayerPrefsKey.BEST_SCORE, 0);
        }
    }

    void Start()
    {
        isGameOver = false;
        score = 0;
        prevTime = Time.time;

        for (int i = 0; i < bulletSpawnerCount; i++)
            Instantiate(
                bulletSpawnerPrefabs[Random.Range(0, bulletSpawnerPrefabs.Length)],
                new Vector3(Random.Range(-Stage.instance.mapSize * 5f + 1f, Stage.instance.mapSize * 5f - 1f),  // x
                            1f,                                                                                 // y
                            Random.Range(-Stage.instance.mapSize * 5f + 1f, Stage.instance.mapSize * 5f - 1f)), // z
                Quaternion.identity,
                parent.transform
            );
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (Time.time - prevTime >= 0.1f)
            {
                AddScore(scoreMultiplier);
                prevTime = Time.time;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneName.PLAY);
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
        MainCanvas.instance.gameOver.gameObject.SetActive(true); // 게임 오버 관련 오브젝트 활성화
    }

    public static GameManager instance;
    [Header("게임 상태 변수")]
    public bool isGameOver;
    [Header("불릿 스포너")]
    public GameObject parent;
    public BulletSpawner[] bulletSpawnerPrefabs;
    public int bulletSpawnerCount;
    [Header("점수 관련 변수")]
    public int score;
    [Tooltip("점수 상승 폭")]
    public int scoreMultiplier;

    float prevTime;
}
