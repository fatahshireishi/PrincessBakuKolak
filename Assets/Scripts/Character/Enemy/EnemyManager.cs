using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    private void Start()
    {
        enemy.ResetValue();
    }
}
