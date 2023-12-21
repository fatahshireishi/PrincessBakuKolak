using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float DurationTransition;
    public string nextScene;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        anim.SetTrigger("Start");
        AudioManager.Instance.PlaySound("MenuClick");
        yield return new WaitForSeconds(DurationTransition);

        SceneManager.LoadScene(nextScene);
    }
}
