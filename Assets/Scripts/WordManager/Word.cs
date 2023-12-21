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
    string wordCorrect;
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

    public bool GetLetter(char type)
    {
        return word[typeIndex] == type;
    }

    public void TypeLetter(char type)
    {
        wordDisplay.EditLetter(type);
        wordCorrect += type;
        typeIndex++;
    }

    public bool CorrectWord(string word)
    {
        return wordCorrect == word;
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
        return wordDisplay != null ? wordDisplay.transform.position : Vector3.zero;
    }

    public void Reset()
    {
        wordDisplay.Reset();
        typeIndex = 0;
    }

    public bool OnLetter()
    {
        return typeIndex > 1;
    }
}