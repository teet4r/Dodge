using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    public static MainCanvas instance = null;
    public Score score;
    public GameOver gameOver;
}
