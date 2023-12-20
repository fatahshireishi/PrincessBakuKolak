using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject obj;

    private void Start()
    {
        if (!Data.isPlayerWin)
        {
            obj.SetActive(false);
        }
    }
}
