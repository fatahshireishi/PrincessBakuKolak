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

    [SerializeField] Enemy enemy;

    [SerializeField] WordManager wordManager;

    [SerializeField] LevelController levelController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ChangePoseCharacter(bool isPlayer)
    {
        // Change player pose
        if (isPlayer) playerPose.GetPoseCharacter();

        // Change enemy pose
        else enemyPose.GetPoseCharacter();
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

    public Vector3 GetPositionGauge(bool isPlayer)
    {
        return isPlayer ? gaugePlayer.gameObject.transform.position : gaugeEnemy.gameObject.transform.position;
    }

    public WordSO GenerateNewWord()
    {
        // Get random word
        return wordGenerator.GetRandomWord();
    }

    public void PlayerAttack()
    {
        ShowCharacter(true, false);
        CharacterLose(false);
        GameOver();
        enemy.EnemyLose();

        // Spawn gameObject Attack player
        spawnPlayerAttack.SpawnNewCharacterAttack();
    }

    public void EnemyAttack()
    {
        ShowCharacter(false, false);
        CharacterLose(true);
        GameOver();

        // Spawn gameObject Attack enemy
        spawnEnemyAttack.SpawnNewCharacterAttack();
    }

    public void GameOver()
    {
        wordManager.WordGameOver();
    }

    public void SpawnTyping(Vector3 position)
    {
        if (wordManager.isGameOver) return;

        wordManager.AddWord(position);
    }

    public void MultipleProggresEnemy(float newMultiple)
    {
        enemy.MultiplePlusProggres(newMultiple);
    }

    public void LoadLevel()
    {
        LevelController newLevel = Instantiate(levelController, Vector3.zero, Quaternion.identity).GetComponent<LevelController>();
        newLevel.LoadNextLevel();
    }
}
