using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    public static MainCanvas instance = null;
    public Score score;
}
