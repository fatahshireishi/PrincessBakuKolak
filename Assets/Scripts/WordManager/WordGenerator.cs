using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    [SerializeField] List<WordSO> wordList = new List<WordSO>();

    public WordSO GetRandomWord()
    {
        int randomIndex = UnityEngine.Random.Range(0, wordList.Count);
        WordSO randomWord = wordList[randomIndex];

        return randomWord;
    }
}
