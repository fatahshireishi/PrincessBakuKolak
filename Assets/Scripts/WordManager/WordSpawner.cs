using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] GameObject wordPrefab;
    [SerializeField] Transform wordCanvas;

    public WordDisplay SpawnWord()
    { 
        GameObject wordObj = Instantiate(wordPrefab, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
    }
}
