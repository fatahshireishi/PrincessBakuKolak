using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterAttack : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] List<float> duration;
    [SerializeField] List<float> moveXValue;
    [SerializeField] bool isCharacter;

    Vector3 startPosition;

    public void SpawnNewCharacterAttack()
    {
        GameObject gameObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        startPosition = gameObject.transform.position;
        DoMove(gameObject);
    }

    void DoMove(GameObject gameObject)
    {
        startPosition.x += moveXValue[0];
        gameObject.transform.DOMoveX(startPosition.x, duration[0]).OnComplete(() =>
        {
            startPosition.x += moveXValue[1];
            gameObject.transform.DOMoveX(startPosition.x, duration[1]).OnComplete(() =>
            {
                startPosition.x += moveXValue[2];
                gameObject.transform.DOMoveX(startPosition.x, duration[2]).OnComplete(() =>
                {
                    GameManager.Instance.ShowCharacter(isCharacter, true);
                    Destroy(gameObject);
                });
            });
        });
    }
}
