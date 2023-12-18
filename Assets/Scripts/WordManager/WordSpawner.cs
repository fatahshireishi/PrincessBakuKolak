using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] GameObject wordPrefab;
    [SerializeField] Transform wordCanvas;

    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-7.5f, 7.5f), 2.25f);
        GameObject wordObj = Instantiate(wordPrefab, randomPosition,Quaternion.identity, wordCanvas);

        return wordObj.GetComponent<WordDisplay>();
    }
}
