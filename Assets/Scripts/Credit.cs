using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Credit : MonoBehaviour
{
    public static Credit Instance;
    [SerializeField] Image whiteBlock;
    [SerializeField] CanvasGroup mainCanvas;
    [SerializeField] CanvasGroup creditCanvas;

    bool creditState;
    bool backCredit;
    public bool initSelect = true;

    [SerializeField] float speedSkip = 15f;
    [SerializeField] Image imageSkip;

    [SerializeField] float ValueImageSkip;

    private void Awake() {
        if (Instance == null) Instance = this;
        this.gameObject.SetActive(false);
    }
    private void Start() {
        creditState = false;
        backCredit = false;
    }

    public void ShowCredit() {
        if (!creditState && !backCredit) {
            AudioManager.Instance.PlaySound("MenuClick");
            creditState = true;
            backCredit = true;
            mainCanvas.DOFade(0, 0.5f).OnComplete(() => {    
                whiteBlock.DOFade(0.5f, 0.5f).OnComplete(() => {
                    creditCanvas.gameObject.SetActive(true);
                    creditCanvas.DOFade(1, 1f);
                });
            });
        }
    }
    public void HideCredit() {
        if (creditState) {
            AudioManager.Instance.PlaySound("MenuClick");
            creditState = false;
            creditCanvas.DOFade(0, 0.5f).OnComplete(() => {
                creditCanvas.gameObject.SetActive(false);
                whiteBlock.DOFade(0f, 0.5f).OnComplete(() => {
                    mainCanvas.gameObject.SetActive(true);
                    mainCanvas.DOFade(1, 1f).OnComplete(() => {
                        //backCredit = false;
                    });
                    imageSkip.transform.DOScale(0, 0f);
                    ValueImageSkip = 0;
                    backCredit = false;
                });
            });
        }
    }

    private void Update() {
        if (backCredit) {
            if (Input.GetKey(KeyCode.Space)) {

                if (ValueImageSkip < 1) {
                    ValueImageSkip += speedSkip * Time.deltaTime;
                    imageSkip.transform.localScale = new Vector3(ValueImageSkip, ValueImageSkip, ValueImageSkip);
                }
                else {
                    HideCredit();
                }

            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                if (ValueImageSkip <= 1) {
                    ValueImageSkip = 0;
                    imageSkip.transform.localScale = new Vector3(ValueImageSkip, ValueImageSkip, ValueImageSkip);
                }
            }
        }
    }
}
