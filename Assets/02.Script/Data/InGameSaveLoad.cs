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

    [Space(10.0f)] [SerializeField] private PpippiEventMgr _ppippiEventMgr;
    [SerializeField] private CampaignUI _campaignUI;
    [SerializeField] private Dropdown _eventListOrderDropDown;
    [SerializeField] private GameObject _newEventItem; // �߻��̺�Ʈ�� ���Ӱ� �����Ǵ� �̺�Ʈ�� ���� �׸�
    [SerializeField] private GameObject _oldEventItem; // �߻��̺�Ʈ�� ���ο�� �ƴ� �̺�Ʈ�� ���� �׸�
    [SerializeField] private int _currOrderValue;
    [SerializeField] private GameObject _ppippiEventPrefabs; // ������ ���� �߻��̺�Ʈ����Ʈ UI

    [Header("=== Memory Board & Fragment ===")]
    [SerializeField] private GameObject[] _memoryFragment; // �� ���ӿ� �ִ� ��� ������
    [SerializeField] private GameObject[] _memoryBoardPieces; 
    [SerializeField] private Text _achieveRate;

    [Header("=== Saving Process ===")]
    [SerializeField] private GameObject _savingText;
    [SerializeField] private float _showTime;

    public GameData _gameData;

    // HideInInspector
    private PlayerAnimatorChange _animChanger;
    private PlayerMemory _playerMemory;
    private WaitForSeconds _ws;

    private void Awake()
    {
        _playerMemory = _player.GetComponent<PlayerMemory>();
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

        _gameData = GameDataPackage._gameData;

        //if (Input.GetKeyDown("l"))
        //{
        //    SaveData loadData = SaveSystem.Load("Save1");
        //    print("Load Success");
        //}
    }

    // ����(����� ���� Json�� �����͸� ������)
    public void SaveToServer(PlayerMemory playerMemory)
    {
        // �� �κ� �Ű������� ���ְ�, �������� _player �� �����ؼ� ���� �ʱ�ȭ ����
        // ���Ŀ� �ٸ� �����鵵 �����ؾ��Ҷ�, �� ��ũ��Ʈ�� ���������� �����ؼ� �ʱ�ȭ ����.

        ppippiEventData newPpippiEvent = null;
        ppippiEventData[] oldPpippiEvents = null;

        if (_newEventItem.transform.childCount != 0)
        {
            newPpippiEvent = _newEventItem.transform.GetChild(0).GetComponent<PpippiEvent>()._eventData;
        }

        if (_oldEventItem.transform.childCount > 0)
        {
            oldPpippiEvents = new ppippiEventData[_oldEventItem.transform.childCount];
            for (int i = 0; i < _oldEventItem.transform.childCount; i++)
            {
                oldPpippiEvents[i] = _oldEventItem.transform.GetChild(i).GetComponent<PpippiEvent>()._eventData;
            }
        }

        StartCoroutine(ShowSaveText());
        GameData saveData =
                new GameData(
                    playerMemory.transform.position,
                    playerMemory._isFragIdxGet,
                    playerMemory._collectMemoryCount,
                    playerMemory._newMemoryIdx,
                    playerMemory._isEntryPlayTimeEnd,
                    playerMemory._isMeetPpippi,
                    playerMemory._memoryPuzzlesActive,
                    newPpippiEvent,
                    oldPpippiEvents
                    );

        SaveData character = new SaveData(saveData);
        if (_isDeveloper)
        {
            SaveSystem.Save(character, "Save4");
            return;
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

        // �߻� �̺�Ʈ �ʱ�ȭ ������

        // �����ƽź��ڸ��� ���� �� ������
        // print(GameDataPackage._gameData._newPpippiEvent._idx == 0); --> 0
        // print(GameDataPackage._gameData._oldPpippiEvents.Length); --> 0

        // � �԰� ���� �� ������ ���� �� ����ȴ�.
        //print(GameDataPackage._gameData._newPpippiEvent._idx);
        //print(GameDataPackage._gameData._oldPpippiEvents.Length);

        if (GameDataPackage._gameData._newPpippiEvent._idx != 0)
        {
            // �̺�Ʈ����Ʈ�� �̹� �ִٴ� ��, �ٵ� �̰� PpippiEventMgr.cs �� CreateNewList �� �� �� ����������?

        }


        // ��� �ؿ��ִ� �ֵ��� ���� ���� �ۼ��ϴ°� �Ǹ� �� ������
        //for (int i = 0; i < GameDataPackage._gameData._oldPpippiEvents.Length; i++)
        //{

        //}

        //string saveFilePath = SaveSystem.SavePath + "Save" + GameDataPackage._index.ToString() + ".json";
        //string saveFile = System.IO.File.ReadAllText(saveFilePath);

        //ppippiEventData newPpippiEvent = null;
        //ppippiEventData[] oldPpippiEvents = null;

        //if (JsonUtility.FromJson<ppippiEventData>(saveFile)._idx != 0)
        //{
        //    newPpippiEvent = JsonUtility.FromJson<ppippiEventData>(saveFile);
        //    PpippiEvent newEventList = Instantiate(_ppippiEventPrefabs, Vector3.zero, Quaternion.identity).GetComponent<PpippiEvent>();

        //    newEventList.SetEventValue(newPpippiEvent);
        //    newEventList.SetParentObj(_newEventItem.transform, PpippiEvent.eMyParentObj.New, _campaignUI, _ppippiEventMgr);
        //}
        //else
        //    print("newEvent null");


        //if (JsonUtility.FromJson<ppippiEventData[]>(saveFile).Length > 1)
        //{
        //    oldPpippiEvents = JsonUtility.FromJson<ppippiEventData[]>(saveFile);
        //    for (int i = 0; i < oldPpippiEvents.Length; i++)
        //    {
        //        PpippiEvent oldEventList = Instantiate(_ppippiEventPrefabs, Vector3.zero, Quaternion.identity).GetComponent<PpippiEvent>();

        //        oldEventList.SetEventValue(oldPpippiEvents[i]);
        //        oldEventList.SetParentObj(_oldEventItem.transform, PpippiEvent.eMyParentObj.Old, _campaignUI, _ppippiEventMgr);
        //    }
        //}
        //else
        //    print("oldEvent null");
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
