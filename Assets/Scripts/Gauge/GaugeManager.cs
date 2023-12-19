using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }

    public void FillImage(float fill)
    {
        image.fillAmount = fill;
    }
}
