using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Credit : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;

    private void Start() 
    {

    }

    public void ShowCredit() 
    {
        menuPanel.SetActive(false);
        gameObject.SetActive(true);
    }
    public void HideCredit() 
    {
        AudioManager.Instance.PlaySound("MenuClick");
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Update() 
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            HideCredit();
        }
    }
}
