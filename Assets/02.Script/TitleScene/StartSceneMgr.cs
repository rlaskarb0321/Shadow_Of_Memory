using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneMgr : MonoBehaviour
{
    public void OnStartBtnClick()
    {
        print("hi");
        LoadingScene.LoadScene("Campaign_1");
    }

    public void OnExitGameBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}