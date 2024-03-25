using UnityEngine;
using UnityEngine.Playables;

// PlayableDirector�� �̿��� �ƽſ������ Ŭ����
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
        // ù ���� ����� "���̵�ƿ� �г�"���� ���̵�ƿ� anim�� �ο��ϰ�
        // anim �������� StartProduction�� ȣ���ϰ�, �ڽ��� ��Ȱ��ȭ�Ѵ�.
        
        if (!GameDataPackage._gameData._isEntryPlayTimeEnd)
        {
            _playableDirector = _firstProduction;
            StartProduction(_playableDirector);
        }
    }

    private void Update()
    {
        // ������ ���
        if (_isPlayProduction && Input.GetKeyDown(KeyCode.End))
        {
            //print("������ ���� ���� ����");
            _playableDirector.time = _playableDirector.duration - 0.2f;
            return;
        }

        if (_playableDirector == null)
            return;

        if (!_playableDirector.gameObject.activeSelf)
            return;

        _isPlayProduction = CheckCutScenePlay();
        //print(_isPlayProduction = CheckCutScenePlay());
    }

    private bool CheckCutScenePlay()
    {
        // ���� ���� or ������ ���� �ٸ��ൿ�� ���ؾ���
        // ������ ��쿣 �÷��� ���ΰſ� �����ϰ� ó��
        // �־��� ������ ���� �Ŀ��� �����־��� playabledirector GameObject�� ��Ȱ��ȭ ��Ű�� ��������� ������ ���ϴ� false�� �����ؾ���
        if (System.Math.Abs(_playableDirector.time - _playableDirector.duration) < 0.05f)
        {
            _playableDirector.gameObject.SetActive(false);
            return false;
        }

        return true;
    }

    // ������ ���۽�Ű�� �Լ�, static���� �����ؼ� �ƹ��� playabledirector�� �ִٸ� ������ �� �ִ�.
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