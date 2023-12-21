using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject winObj;
    [SerializeField] GameObject loseObj;

    private void Start()
    {
        if (!Data.isPlayerWin)
        {
            loseObj.SetActive(true);
            winObj.SetActive(false);
        }
        else
        {
            winObj.SetActive(true);
            loseObj.SetActive(false);
        }

    }
}
