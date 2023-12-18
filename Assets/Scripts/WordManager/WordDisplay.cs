using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class WordDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    string wordCurrent;
    string letter;

    public void SetWord(string _word)
    {
        wordCurrent = _word;/*(robin)*/
        text.text = wordCurrent;
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

        string LetterColor = "<color=#fff321>" + letter + "</color>";
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

        text.text = LetterColor + wordCurrent;
        /*
         * (r(color yellow)obin)
         * (ro(color yellow)bin)
         * (rob(color yellow)in)
         * (robi(color yellow)n)
         * (robin(color yellow))
         */
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    void EditColorText()
    {

    }
}