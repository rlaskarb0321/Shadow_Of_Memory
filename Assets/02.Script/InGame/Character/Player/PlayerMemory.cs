using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerMemory : MonoBehaviour
{
    // SerializeField
    [Header("=== Memory Frament ===")] 
    public bool[] _isFragIdxGet; // 인덱스번째의 기억을 얻은 여부를 저장
    public int _newMemoryIdx; // 플레이어가 최근에 획득한 기억조각의 번호, 삐삐와의 스토리대화를 요청하면 최근 획득한 기억조각 번호번째 대화가 출력됨
    public int _collectMemoryCount; // 총 모은 기억의 수
    public PlayableDirector _endingCutScene; // 기억 조각을 다 모은 후 재생할 컷신

    [Header("=== Memory Board ===")] 
    [SerializeField] private GameObject[] _memoryPuzzles; // 기억퍼즐들
    [HideInInspector] public Text _currCollectText; // 현재 모은 수
    [HideInInspector] public Text _acheiveRateText; // 달성률을 표시하는 텍스트
    [SerializeField] private Text _descriptionText; // 활성화된 기억을 클릭했을때 관련 설명을 표시할 텍스트
    [SerializeField] private string[] _descriptionContent; // 기억 관련 설명의 내용
    
    [Header("=== Black Cloud Note ===")]
    [SerializeField] private Image _memoryImage; // 습득한 기억퍼즐의 이미지
    [SerializeField] private GameObject _blackCloudNote; // 검은구름배경의 쪽지
    [SerializeField] private Text _blackCloudTitle; // 쪽지의 제목
    [SerializeField] private Text _blackCloudContext; // 쪽지의 내용

    [Header("=== Save System ===")]
    [SerializeField] private GameObject _inGameSaveLoadObj;

    // HideInInspector
    [HideInInspector] public bool _isEntryPlayTimeEnd;
    [HideInInspector] public bool _isMeetPpippi;
    private InGameSaveLoad _inGameSaveLoad;
    private PlayerAnimatorChange _animChange;
    [HideInInspector] public bool[] _memoryPuzzlesActive;

    private void Awake()
    {
        _animChange = GetComponent<PlayerAnimatorChange>();
        _inGameSaveLoad = _inGameSaveLoadObj.GetComponent<InGameSaveLoad>();
    }


    private void Start()
    {
        _descriptionText.text = "";

        _memoryPuzzlesActive = new bool[ConstData._TOTALMEMORYCOUNT];
    }

    public void GetMemoryFragment(int index, Sprite memoryImage)
    {
        _memoryImage.sprite = memoryImage;
        _memoryImage.SetNativeSize();

        // 사운드 연출
        // Do somthing

        CountMemoryFragment(index); // 습득 후 Player쪽 처리
        UpdateMemoryBoard(index); // 습득 후 MemoryBoard쪽 처리
        ShowBlackCloudNote(index); // 쪽지연출
        _inGameSaveLoad.SaveToServer(this); // 자동 저장

        
    }

    // 메모리 보드에있는 퍼즐을 클릭할 때 
    public void OnClickMemoryPuzzle(int index)
    {
        _descriptionText.text = _descriptionContent[index - 1];
    }

    // 삐삐와의 상호작용 대화에서 기억관련 선택지를 골랐을 때
    public void OnClickStoryDialog()
    {
        if (_collectMemoryCount == 0)
        {
            print("현재 수집한 기억이 없습니다");
            return;
        }

        print(_newMemoryIdx + "번 째 스토리 대화가 출력");
    }

    private void CountMemoryFragment(int index)
    {
        // 모은 조각수 +1
        _collectMemoryCount++;

        // 최근 먹은 기억의 인덱스값 갱신, 해당 조각의 인덱스값 먹음처리
        _newMemoryIdx = index;
        _isFragIdxGet[index - 1] = true;


        if (_collectMemoryCount == ConstData._COLLECTLEVEL2)
        {
            _animChange.ChangeAnimator(1);
        }

        if (_collectMemoryCount == ConstData._COLLECTLEVEL3)
        {
            _animChange.ChangeAnimator(2);
        }
    }

    private void UpdateMemoryBoard(int index)
    {
        // 먹은 기억퍼즐 이미지 활성화
        _memoryPuzzles[index - 1].gameObject.SetActive(true);
        _memoryPuzzlesActive[index - 1] = true;

        // 달성률과 진행도 최신화
        _acheiveRateText.text = string.Format("{0:f2} %", (_collectMemoryCount / 6.0f) * 100.0f);
        _currCollectText.text = _collectMemoryCount.ToString();
    }

    private void ShowBlackCloudNote(int index)
    {
        // 쪽지관련 string값을 제목, 본문으로 나눠 담음
        string[] contextLine = _descriptionContent[index - 1].Split('\\');
        string title = contextLine[0];
        string context = contextLine[1];

        if (_blackCloudNote.activeSelf)
            _blackCloudNote.SetActive(false);

        _blackCloudNote.SetActive(true);
        _blackCloudTitle.text = title;
        _blackCloudContext.text = context;

        // 다 모았을 경우
        if (_collectMemoryCount.Equals(ConstData._TOTALMEMORYCOUNT))
        {
            StartCoroutine(StartEndingCutScene());
            return;
        }
    }

    private IEnumerator StartEndingCutScene()
    {
        yield return new WaitUntil(() => !_blackCloudNote.activeSelf);
        yield return new WaitForSeconds(1.5f);

        ProductionMgr.StartProduction(_endingCutScene);
    }
}
