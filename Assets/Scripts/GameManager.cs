using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] CharacterPose playerPose;
    [SerializeField] CharacterPose enemyPose;

    [SerializeField] GaugeManager gaugePlayer;
    [SerializeField] GaugeManager gaugeEnemy;

    [SerializeField] WordGenerator wordGenerator;

    [SerializeField] SpawnCharacterAttack spawnPlayerAttack;
    [SerializeField] SpawnCharacterAttack spawnEnemyAttack;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ChangePoseCharacter(bool isCharcater, int indexPose = 1)
    {
        // Change player pose
        if (isCharcater) playerPose.GetPoseCharacter(indexPose);

        // Change enemy pose
        else enemyPose.GetPoseCharacter(indexPose);
    }

    public void CharacterLose(bool isCharcater)
    {
        // Change player lose pose
        if (isCharcater) playerPose.GetPoseCharacterLose();

        // Change enemy lose pose
        else enemyPose.GetPoseCharacterLose();
    }

    public void ShowCharacter(bool isCharacter, bool isShow)
    {
        // Hide gameObject player
        if(isCharacter) playerPose.gameObject.SetActive(isShow);

        // Hide gameObject enemy
        else enemyPose.gameObject.SetActive(isShow);
    }

    public void FillGaugecharacter(bool isCharacer, float fill)
    {
        // Fill Gauge player
        if (isCharacer) gaugePlayer.FillImage(fill);

        //Fill Gauge Enemy
        else gaugeEnemy.FillImage(fill);
    }

    public WordSO GenerateNewWord()
    {
        // Get random word
        return wordGenerator.GetRandomWord();
    }

    public void PlayerAttack()
    {
        ShowCharacter(true, false);
        // Spawn gameObject Attack player
        spawnPlayerAttack.SpawnNewCharacterAttack();
    }

    public void EnemyAttack()
    {
        ShowCharacter(false, false);
        // Spawn gameObject Attack enemy
        spawnEnemyAttack.SpawnNewCharacterAttack();
    }
}
