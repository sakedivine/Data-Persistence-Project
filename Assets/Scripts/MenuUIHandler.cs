using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    public void StartGame()
    {
        if (inputField.text.Length > 0)
        {
            ScoreManager.Instance.playerName = inputField.text;
            SceneManager.LoadScene(1);
        }
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}