using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    string wordCurrent;
    string letter;
    string letterColor;
    string wordDefault;

    private void Start()
    {
        
    }

    public void SetWord(string _word)
    {
        wordCurrent = _word;/*(robin)*/
        text.text = wordCurrent;
        wordDefault = _word;
    }

    public void EditLetter(char word)
    {
        letter += word;
        /*
         * (r)
         * (ro)
         * (rob)
         * (robi)
         * (robin)
         */

         letterColor = "<color=#fff321>" + letter + "</color>";
        /*
         * (r(Color yellow))
         * (ro(Color yellow))
         * (rob(Color yellow))
         * (robi(Color yellow))
         * (robin(Color yellow))
         */

        wordCurrent = wordCurrent.Remove(0, 1);
        /*
         * (obin)
         * (bin)
         * (in)
         * (n)
         * ()
         */

        text.text = letterColor + wordCurrent;
        /*
         * (r(color yellow)obin)
         * (ro(color yellow)bin)
         * (rob(color yellow)in)
         * (robi(color yellow)n)
         * (robin(color yellow))
         */
    }

    public void EditWrongLetter()
    {
        char TypeWrong = wordCurrent[0];
        string wrongLetterCol = letterColor + "<color=#FF0000>" + "<b>" + TypeWrong + "</b>" + "</color>";
        wordCurrent = wordCurrent.Remove(0, 1);
        text.text = wrongLetterCol + wordCurrent;
        wordCurrent = TypeWrong + wordCurrent;
    }

    public void RemoveWord()
    {
        if (gameObject != null) Destroy(gameObject);
    }

    public void Reset()
    {
        text.text = wordDefault;
    }
}