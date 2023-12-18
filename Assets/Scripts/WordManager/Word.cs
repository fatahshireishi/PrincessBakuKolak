using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;

    public int typeIndex;

    WordDisplay wordDisplay;

    public Word(string _word, WordDisplay _wordDisplay)
    {
        word = _word;
        typeIndex = 0;
        wordDisplay = _wordDisplay;
        wordDisplay.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        wordDisplay.EditLetter(word[typeIndex]);
        typeIndex++;
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            wordDisplay.RemoveWord();
        }
        return wordTyped;
    }
}