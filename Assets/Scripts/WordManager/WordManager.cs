using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    Word activeWord;

    WordSpawner spawner;
    [SerializeField] List<Transform> spawnLocation;

    bool hasActiveWord;
    [HideInInspector]
    public bool isGameOver = false;

    float Proggres;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<WordSpawner>();
        for (int i = 0; i < spawnLocation.Count; i++)
        {
            AddWord(spawnLocation[i].position);
        }
    }

    public void AddWord(Vector3 position)
    {
        Word word = new Word(GameManager.Instance.GenerateNewWord(), spawner.SpawnWord(position));

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (isGameOver) return;

        if (hasActiveWord)
        {
            if (activeWord.GetLetter(letter))
            {
                AudioManager.Instance.PlaySound("Typing");
                activeWord.TypeLetter(letter);
            }
            else
            {
                AudioManager.Instance.PlaySound("TypingWrong");
                activeWord.WrongLetter();
                spawner.SpawnTyping(letter.ToString(), activeWord.GetLocationWord(), GameManager.Instance.GetPositionGauge(false), activeWord.enemyPlusProggres);
            }
        }
        else
        {
            for (int i = 0;i < words.Count;i++)
            {
                if (words[i].GetLetter(letter))
                {
                    words[i].TypeLetter(letter);
                    hasActiveWord = true;
                    activeWord = words[i];
                    AudioManager.Instance.PlaySound("Typing");
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            Proggres += activeWord.proggres;
            spawner.SpawnNewWord(activeWord.word, activeWord.GetLocationWord(), GameManager.Instance.GetPositionGauge(true));
            GameManager.Instance.ChangePoseCharacter(true);
            GameManager.Instance.FillGaugecharacter(true, Proggres);
            // Win Condition
            if (Proggres >= 1)
            {
                Data.isPlayerWin = true;
                GameManager.Instance.PlayerAttack();
                AudioManager.Instance.PlaySound("PlayerWin");
                return;
            }
            words.Remove(activeWord);
        }
    }

    public void WordGameOver()
    {
        for (int i = 0; i < words.Count; i++)
        {
            Destroy(words[i].wordDisplay.gameObject);
        }
        words.Clear();

        isGameOver = true;
    }

    public void HideWord(bool isShow)
    {
        for (int i = 0; i < words.Count; i++)
        {
            words[i].wordDisplay.gameObject.SetActive(!isShow);
        }
    }
}

