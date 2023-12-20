using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] GameObject wordPrefab;
    [SerializeField] Transform wordCanvas;

    public WordDisplay SpawnWord(Vector3 position)
    {
        GameObject wordObj = Instantiate(wordPrefab, position, Quaternion.identity, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
    }
}
