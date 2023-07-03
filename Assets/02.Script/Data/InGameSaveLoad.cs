using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ķ���� ���� �ִ� ��ũ��Ʈ
public class InGameSaveLoad : MonoBehaviour
{
    // SeriralizeField
    [Header("=== Developer Only Save File ===")]
    [Tooltip("������ ����, ķ���ξ����� ������ �� �÷��̾� ��ġ ���� ����")]
    public bool _isDeveloper;

    [Header("=== Extract List ===")]
    [SerializeField] private GameObject _player; // �÷��̾�
    [SerializeField] private GameObject _groundColl; // �÷��̾� ���� ���� ���� ���� �ݸ���

    [Space(10.0f)] [SerializeField] private GameObject _stubObj; // �߻߰� �ɾ��ִ� �׷��ͱ�
    [SerializeField] private GameObject _dummyPpippi; // ���� �߻�
    [SerializeField] private GameObject _realPpippi; // ��¥ �߻�

    [Header("=== Memory Board & Fragment ===")]
    [SerializeField] private GameObject[] _memoryFragment; // �� ���ӿ� �ִ� ��� ������
    [SerializeField] private GameObject[] _memoryBoardPieces; 
    [SerializeField] private Text _achieveRate;

    [Header("=== Saving Process ===")]
    [SerializeField] private GameObject _savingText;
    [SerializeField] private float _showTime;

    // HideInInspector
    private CapsuleCollider2D _playerColl;
    private BoxCollider2D _groundBoxColl;
    private PlayerAnimatorChange _animChanger;
    private PlayerMemory _playerMemory;
    private WaitForSeconds _ws;

    private void Awake()
    {
        _playerMemory = _player.GetComponent<PlayerMemory>();
        _playerColl = _player.GetComponent<CapsuleCollider2D>();
        _groundBoxColl = _groundColl.GetComponent<BoxCollider2D>();
        _animChanger = _player.GetComponent<PlayerAnimatorChange>();
        _ws = new WaitForSeconds(_showTime);
    }

    private void Start()
    {
        // start�� awake���� ȣ�� �ӵ��� �����Ƿ� ���⼭ ������ �ʱ�ȭ�� ����
        ApplyDataToGame();
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            SaveToServer(_playerMemory);
        }

        //if (Input.GetKeyDown("l"))
        //{
        //    SaveData loadData = SaveSystem.Load("Save1");
        //    print("Load Success");
        //}
    }

    // ����(����� ���� Json�� �����͸� ������)
    public void SaveToServer(PlayerMemory playerMemory)
    {
        StartCoroutine(ShowSaveText());
        GameData saveData =
                new GameData(
                    playerMemory.transform.position,
                    playerMemory._isFragIdxGet,
                    playerMemory._collectMemoryCount,
                    playerMemory._newMemoryIdx,
                    playerMemory._isEntryPlayTimeEnd,
                    playerMemory._isMeetPpippi,
                    playerMemory._memoryPuzzlesActive
                    );

        SaveData character = new SaveData(saveData);
        if (_isDeveloper)
        {
            SaveSystem.Save(character, "Save4");
        }
        SaveSystem.Save(character, "Save" + GameDataPackage._index.ToString());
    }

    private void ApplyDataToGame()
    {
        // �ΰ��� ���� ��ҵ��� ���� �����Ϳ� ����� ������ �ٲ۴�.
        if (_isDeveloper)
        {
            _playerMemory.transform.position = _playerMemory.transform.position;
        }
        else
        {
            _playerMemory.transform.position = GameDataPackage._gameData._playerPos;            // �÷��̾��� ��ġ
        }

        _playerMemory._isFragIdxGet = GameDataPackage._gameData._isFragIdxGet;              // ���° �ε����� ��������� �Ծ����� �ƴ���
        _playerMemory._collectMemoryCount = GameDataPackage._gameData._currCollectCount;    // ���� ���� ��� ���� ����
        _playerMemory._newMemoryIdx = GameDataPackage._gameData._newMemoryIdx;              // ���� ���� ����� �ε��� ��
        _playerMemory._isEntryPlayTimeEnd = GameDataPackage._gameData._isEntryPlayTimeEnd;  // ���� �ƽ� �ô���
        _playerMemory._isMeetPpippi = GameDataPackage._gameData._isMeetPpippi;              // �׷��ͱ⿡ �ɾ��ִ� �߻߿ʹ� ��������

        // �߻߸� �����ٸ�, ���� ����Obj���� ���� �ٲ��ش�
        if (_playerMemory._isMeetPpippi)
        {
            _dummyPpippi.gameObject.SetActive(false);
            _realPpippi.gameObject.SetActive(true);
            _stubObj.GetComponent<BoxCollider2D>().enabled = false;
        }

        // �ΰ��� ������� �ε����� �޸� ���� �������θ� ������ ���� ����ȭ
        for (int i = 0; i < _memoryFragment.Length; i++)                
        {
            bool isActive = GameDataPackage._gameData._isFragIdxGet[i];
            _memoryFragment[i].SetActive(!isActive);
            _memoryBoardPieces[i].SetActive(isActive);
        }

        // �޸𸮺��� �޼��� ����
        _playerMemory._acheiveRateText.text = string.Format("{0:f2} %", (GameDataPackage._gameData._currCollectCount / 6.0f) * 100.0f);
        _playerMemory._currCollectText.text = GameDataPackage._gameData._currCollectCount.ToString(); // n / 6 ���� ����

        // ���� ��� ���� �������� �÷��̾� ���尪 ����, �ִϸ����� �Ҵ�
        if (ConstData._COLLECTLEVEL2 <= GameDataPackage._gameData._currCollectCount &&
            GameDataPackage._gameData._currCollectCount < ConstData._COLLECTLEVEL3)
        {
            // 2 ���� ĳ����
            _animChanger.ChangeAnimator(1);
        }

        if (ConstData._COLLECTLEVEL3 <= GameDataPackage._gameData._currCollectCount)
        {
            // 3 ���� ĳ����
            _animChanger.ChangeAnimator(2);
        }
    }

    private IEnumerator ShowSaveText()
    {
        if (_savingText.activeSelf)
            _savingText.SetActive(false);

        _savingText.SetActive(true);
        yield return _ws;
        _savingText.SetActive(false);

    }
}
