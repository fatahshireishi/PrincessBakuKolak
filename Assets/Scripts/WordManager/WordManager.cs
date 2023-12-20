using DG.Tweening;
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
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
            else
            {
                GameManager.Instance.MultipleProggresEnemy(activeWord.enemyPlusProggres);
                activeWord.WrongLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    activeWord.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            Proggres += activeWord.proggres;
            spawner.SpawnTyping(activeWord.word, activeWord.GetLocationWord(), GameManager.Instance.GetPositionGauge(true));
            GameManager.Instance.ChangePoseCharacter(true);
            GameManager.Instance.FillGaugecharacter(true, Proggres);
            // Win Condition
            if (Proggres >= 1)
            {
                GameManager.Instance.PlayerAttack();
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
}

