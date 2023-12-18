using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    WordManager wordManager;

    private void Start()
    {
        wordManager = GetComponent<WordManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            wordManager.TypeLatter(letter);
        }
    }
}
