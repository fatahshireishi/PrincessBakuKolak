using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    bool hasActiveWord;
    Word activeWord;

    [SerializeField] int wordCount = 1;

    WordSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<WordSpawner>();
        for (int i = 0; i < wordCount; i++)
        {
            AddWord();
        }
    }

    private void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), spawner.SpawnWord());

        Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeLatter(char letter)
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
            words.Remove(activeWord);
        }
    }
}
