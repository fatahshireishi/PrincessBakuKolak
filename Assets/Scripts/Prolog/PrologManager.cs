using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PrologManager : MonoBehaviour
{
    Vector3 targetPosition;

    [SerializeField] LevelController levelController;
    [SerializeField] float durationMove = 15f;
    [SerializeField] float speedSkip = 15f;
    [SerializeField] Image imageSkip;
    bool isSkip;

    float ValueImageSkip;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.StopSound("MainTheme", 0.2f);
        StartCoroutine(PlaySound());
        imageSkip.transform.localScale = Vector3.zero;
        targetPosition.y = -transform.position.y;
        transform.DOMoveY(targetPosition.y, durationMove).OnComplete(() =>
        {
            levelController.LoadNextLevel();
        });
    }

    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.2f);

        AudioManager.Instance.PlaySound("MainTheme");
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(!isSkip)
            {
                if (ValueImageSkip < 1)
                {
                    ValueImageSkip += speedSkip * Time.deltaTime;
                    imageSkip.transform.localScale = new Vector3(ValueImageSkip, ValueImageSkip, ValueImageSkip);
                }
                else
                {
                    isSkip = true;
                    levelController.LoadNextLevel();
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            if(!isSkip)
            {
                if(ValueImageSkip <= 1)
                {
                    ValueImageSkip = 0;
                    imageSkip.transform.localScale = new Vector3(ValueImageSkip, ValueImageSkip, ValueImageSkip);
                }
            }
        }
    }
}
