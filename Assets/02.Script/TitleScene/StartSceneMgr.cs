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
}