using UnityEngine;
using UnityEngine.Playables;

// PlayableDirector를 이용한 컷신연출관련 클래스
public class ProductionMgr : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _firstProduction;
    [SerializeField]
    private GameObject _pausePanel;

    private static PlayableDirector _playableDirector;
    public static bool _isPlayProduction;

    private void Start()
    {
        _playableDirector = _firstProduction;
        StartProduction(_playableDirector);
    }

    private void Update()
    {
        if (_playableDirector == null)
            return;

        if (!_playableDirector.gameObject.activeSelf)
            return;

        _isPlayProduction = CheckCutScenePlay();
        //print(_isPlayProduction = CheckCutScenePlay());
    }

    private bool CheckCutScenePlay()
    {
        // 연출 퍼즈 or 끝남에 따라 다른행동을 취해야함
        // 퍼즈인 경우엔 플레이 중인거와 유사하게 처리
        // 주어진 연출이 끝난 후에는 전해주었던 playabledirector GameObject를 비활성화 시키고 재생중이지 않음을 뜻하는 false를 리턴해야함
        if (System.Math.Abs(_playableDirector.time - _playableDirector.duration) < 0.1f)
        {
            _playableDirector.gameObject.SetActive(false);
            return false;
        }

        return true;
    }

    // 연출을 동작시키는 함수, static으로 접근해서 아무나 playabledirector가 있다면 실행할 수 있다.
    public static void StartProduction(PlayableDirector playableDirector)
    {
        if (playableDirector.gameObject == null)
        {
            print("playableDirector is null !!");
            return;
        }

        if (!playableDirector.gameObject.activeSelf)
            playableDirector.gameObject.SetActive(true);

        _playableDirector = playableDirector;
        _playableDirector.Play();
    }
}
