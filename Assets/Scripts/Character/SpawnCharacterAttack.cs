using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float duration = 2.0f;
    [SerializeField] float moveXValue = -100.0f;
    [SerializeField] bool isCharacter;

    Vector3 startPosition;

    public void SpawnNewCharacterAttack()
    {
        GameObject gameObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
        startPosition = gameObject.transform.position;
        DoMove(gameObject);
    }

    void DoMove(GameObject gameObject)
    {
        startPosition.x += moveXValue;
        gameObject.transform.DOMoveX(startPosition.x, duration).SetEase(Ease.InSine).OnComplete(() =>
        {
            GameManager.Instance.ShowCharacter(isCharacter, true);
            Destroy(gameObject);
        });
    }
}
