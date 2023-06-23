using UnityEngine;

public class MainBackGround : MonoBehaviour
{
    [SerializeField] private GameObject _saveList;

    public void OnSaveListClick()
    {
        bool isSaveListActive = _saveList.activeSelf;
        _saveList.SetActive(!isSaveListActive);
    }

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