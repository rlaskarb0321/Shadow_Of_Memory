using UnityEngine;

public class MainBackGround : MonoBehaviour
{
    public void OnCampaignBtnClick()
    {
        LoadingScene.LoadScene("Campaign");
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