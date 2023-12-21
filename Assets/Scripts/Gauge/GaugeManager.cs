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
        image.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void FillImage(float fill)
    {
        if (fill >= 1.0f) fill = 1.0f;

        image.gameObject.transform.localScale = new Vector3(fill, fill, fill);
    }
}
