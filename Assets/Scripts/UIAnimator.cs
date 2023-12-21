using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimator : MonoBehaviour
{
    private Color color;
    private float yPos;
    private Outline outline;

    private void Start() {
        yPos = GetComponent<RectTransform>().position.y;
        color = GetComponent<Image>().color;
        outline = GetComponent<Outline>();
    }
    public void Hover() {
        if (Credit.Instance.initSelect) Credit.Instance.initSelect = false;
        else AudioManager.Instance.PlaySound("MenuHover");
        GetComponent<RectTransform>().DOScale(1.1f, 0.1f);
        GetComponent<RectTransform>().DOMoveY(yPos + 0.05f, 0.1f);
        GetComponent<Image>().DOColor(Color.white, 0.15f);
        outline.enabled = true;
    }
    public void Unhover() {
        GetComponent<RectTransform>().DOScale(1f, 0.1f);
        GetComponent<RectTransform>().DOMoveY(yPos, 0.1f);
        GetComponent<Image>().DOColor(color, 0.15f);
        outline.enabled = false;
    }

}
