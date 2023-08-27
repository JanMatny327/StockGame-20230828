using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    public void GameStart_Button()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GameStop_Button()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
