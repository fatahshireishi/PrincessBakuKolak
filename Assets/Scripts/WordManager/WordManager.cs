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

    private void AddWord(Vector3 position)
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
            GameManager.Instance.ChangePoseCharacter(true, Random.Range(0, 5));
            GameManager.Instance.FillGaugecharacter(true, Proggres);
            // Win Condition
            if (Proggres >= 1)
            {
                GameManager.Instance.PlayerAttack();
                GameManager.Instance.CharacterLose(false);
                for (int i = 0; i < words.Count; i++)
                {
                    Destroy(words[i].wordDisplay.gameObject);
                }
                words.Clear();
                return;
            }
            AddWord(activeWord.GetLocationWord());
            words.Remove(activeWord);
        }
    }
}

