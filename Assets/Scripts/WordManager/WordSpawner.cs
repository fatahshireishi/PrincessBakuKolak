using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] GameObject wordPrefab;
    [SerializeField] GameObject wordType;
    [SerializeField] Transform wordCanvas;

    public WordDisplay SpawnWord(Vector3 position)
    {
        GameObject wordObj = Instantiate(wordPrefab, position, Quaternion.identity, wordCanvas);
        return wordObj.GetComponent<WordDisplay>();
    }

    public void SpawnNewWord(string wordLetter, Vector3 position, Vector3 targetPos)
    {
        GameObject TypeObj = Instantiate(wordPrefab, position, Quaternion.identity, wordCanvas);
        TypeObj.GetComponent<WordDisplay>().SetWord(wordLetter);
        TypeObj.transform.DOMove(targetPos, 1.0f).OnComplete(() =>
        {
            GameManager.Instance.SpawnTyping(position);
            Destroy(TypeObj);
        });
    }

    public void SpawnTyping(string wordLetter, Vector3 position, Vector3 targetPos, float enemyPlusProggres)
    {
        GameObject TypeObj = Instantiate(wordType, position, Quaternion.identity, wordCanvas);
        TypeObj.GetComponent<WordDisplay>().SetWord(wordLetter);
        TypeObj.transform.DOMove(targetPos, 1.0f).OnComplete(() =>
        {
            GameManager.Instance.MultipleProggresEnemy(enemyPlusProggres);
            Destroy(TypeObj);
        });
    }
}
