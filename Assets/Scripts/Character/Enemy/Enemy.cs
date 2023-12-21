using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    float FillValue;
    float proggres;

    float plusProggres = 0.01f;

    bool canFill = true;
    bool isLose = false;

    private void Update()
    {
        if (canFill)
        {
            if (isLose) return;
            FillValue += speed * Time.deltaTime;
            if (FillValue >= 1)
            {
                canFill = false;
                proggres += plusProggres;
                GameManager.Instance.FillGaugecharacter(false, proggres);
                GameManager.Instance.ChangePoseCharacter(false);
                if (proggres >= 1)
                {
                    GameManager.Instance.EnemyAttack();
                    Data.isPlayerWin = false;
                    return;
                }
                ResetValue();
            }
        }
    }

    public void ResetValue()
    {
        canFill = true;
        FillValue = 0;
    }

    public void EnemyLose()
    {
        canFill = false;
        FillValue = 0;
        proggres = 0;
        isLose = true;
    }

    public void MultiplePlusProggres(float newPlusProggres)
    {
        plusProggres += newPlusProggres;
    }
}
