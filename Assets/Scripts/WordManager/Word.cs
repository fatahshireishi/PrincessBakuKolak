using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public float proggres;
    public float enemyPlusProggres;

    public int typeIndex;

    public WordDisplay wordDisplay;

    public Word(WordSO _word, WordDisplay _wordDisplay)
    {
        word = _word.name;
        proggres = _word.proggres;
        enemyPlusProggres = _word.enemyPlusProggres;
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

    public void WrongLetter()
    {
        wordDisplay.EditWrongLetter();
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

    public Vector3 GetLocationWord()
    {
        return wordDisplay.transform.position;
    }
}