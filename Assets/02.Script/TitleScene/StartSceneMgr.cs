using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneMgr : MonoBehaviour
{
    [Header("=== BackGround ===")]
    [SerializeField]
    private GameObject _titleBackGround;

    [SerializeField]
    private GameObject _mainBackGround;

    [Space(10.0f)]
    [SerializeField]
    private Image _fadeInOutPanel;

    // Method
    #region Start Scene
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
    #endregion Start Scene

    public IEnumerator FadeInOutPanel(float initDelay, GameObject currBackGround, GameObject nextBackground)
    {
        yield return new WaitForSeconds(initDelay);

        // ¾îµÓ°Ô
        _fadeInOutPanel.gameObject.SetActive(true);

        Color color = _fadeInOutPanel.color;
        float time = 0.0f;
        while (time <= 1.0f)
        {
            color.a = time;
            _fadeInOutPanel.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        nextBackground.SetActive(true);

        // ¹à°Ô
        time = 1.0f;
        while (time >= 0.0f)
        {
            color.a = time;
            _fadeInOutPanel.color = color;
            time -= Time.deltaTime;
            yield return null;
        }

        currBackGround.SetActive(false);
        _fadeInOutPanel.gameObject.SetActive(false);
    }


}