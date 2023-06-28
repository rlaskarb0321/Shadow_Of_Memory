using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerMemory : MonoBehaviour
{
    // SerializeField
    [Header("=== Memory Frament ===")] 
    public bool[] _isFragIdxGet; // �ε�����°�� ����� ���� ���θ� ����
    public int _newMemoryIdx; // �÷��̾ �ֱٿ� ȹ���� ��������� ��ȣ, �߻߿��� ���丮��ȭ�� ��û�ϸ� �ֱ� ȹ���� ������� ��ȣ��° ��ȭ�� ��µ�
    public int _collectMemoryCount; // �� ���� ����� ��
    public PlayableDirector _endingCutScene; // ��� ������ �� ���� �� ����� �ƽ�

    [Header("=== Memory Board ===")] 
    [SerializeField] private GameObject[] _memoryPuzzles; // ��������
    [HideInInspector] public Text _currCollectText; // ���� ���� ��
    [HideInInspector] public Text _acheiveRateText; // �޼����� ǥ���ϴ� �ؽ�Ʈ
    [SerializeField] private Text _descriptionText; // Ȱ��ȭ�� ����� Ŭ�������� ���� ������ ǥ���� �ؽ�Ʈ
    [SerializeField] private string[] _descriptionContent; // ��� ���� ������ ����
    
    [Header("=== Black Cloud Note ===")]
    [SerializeField] private Image _memoryImage; // ������ ��������� �̹���
    [SerializeField] private GameObject _blackCloudNote; // ������������� ����
    [SerializeField] private Text _blackCloudTitle; // ������ ����
    [SerializeField] private Text _blackCloudContext; // ������ ����

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

        // ���� ����
        // Do somthing

        CountMemoryFragment(index); // ���� �� Player�� ó��
        UpdateMemoryBoard(index); // ���� �� MemoryBoard�� ó��
        ShowBlackCloudNote(index); // ��������
        _inGameSaveLoad.SaveToServer(this); // �ڵ� ����

        
    }

    // �޸� ���忡�ִ� ������ Ŭ���� �� 
    public void OnClickMemoryPuzzle(int index)
    {
        _descriptionText.text = _descriptionContent[index - 1];
    }

    // �߻߿��� ��ȣ�ۿ� ��ȭ���� ������ �������� ����� ��
    public void OnClickStoryDialog()
    {
        if (_collectMemoryCount == 0)
        {
            print("���� ������ ����� �����ϴ�");
            return;
        }

        print(_newMemoryIdx + "�� ° ���丮 ��ȭ�� ���");
    }

    private void CountMemoryFragment(int index)
    {
        // ���� ������ +1
        _collectMemoryCount++;

        // �ֱ� ���� ����� �ε����� ����, �ش� ������ �ε����� ����ó��
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
        // ���� ������� �̹��� Ȱ��ȭ
        _memoryPuzzles[index - 1].gameObject.SetActive(true);
        _memoryPuzzlesActive[index - 1] = true;

        // �޼����� ���൵ �ֽ�ȭ
        _acheiveRateText.text = string.Format("{0:f2} %", (_collectMemoryCount / 6.0f) * 100.0f);
        _currCollectText.text = _collectMemoryCount.ToString();
    }

    private void ShowBlackCloudNote(int index)
    {
        // �������� string���� ����, �������� ���� ����
        string[] contextLine = _descriptionContent[index - 1].Split('\\');
        string title = contextLine[0];
        string context = contextLine[1];

        if (_blackCloudNote.activeSelf)
            _blackCloudNote.SetActive(false);

        _blackCloudNote.SetActive(true);
        _blackCloudTitle.text = title;
        _blackCloudContext.text = context;

        // �� ����� ���
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
