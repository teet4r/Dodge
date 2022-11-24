using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    public static LobbyManager instance = null;
}
