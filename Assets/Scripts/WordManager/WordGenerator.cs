using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    [SerializeField] List<WordSO> wordList = new List<WordSO>();
    int wordIndex = 0;

    public WordSO GetRandomWord()
    {
        WordSO randomWord = wordList[wordIndex];
        wordIndex += 1;
        if (wordIndex >= wordList.Count) wordIndex = 0;

        return randomWord;
    }
}
