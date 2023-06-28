using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ķ���� ���� �ִ� ��ũ��Ʈ
public class InGameSaveLoad : MonoBehaviour
{
    // SeriralizeField
    [Header("=== Extract List ===")]
    [SerializeField] private GameObject _player; // �÷��̾�
    [SerializeField] private GameObject _groundColl; // �÷��̾� ���� ���� ���� ���� �ݸ���
    [SerializeField] private GameObject _stubObj; // �߻߰� �ɾ��ִ� �׷��ͱ�
    [SerializeField] private GameObject _dummyPpippi; // ���� �߻�
    [SerializeField] private GameObject _realPpippi; // ��¥ �߻�
    [SerializeField] private GameObject[] _memoryFragment; // �� ���ӿ� �ִ� ��� ������

    [Header("=== Saving Process ===")]
    [SerializeField] private GameObject _savingText;
    [SerializeField] private float _showTime;

    // HideInInspector
    private CapsuleCollider2D _playerColl;
    private BoxCollider2D _groundBoxColl;
    private PlayerMemory _playerMemory;
    private PpippiStub _ppippiStub;
    private WaitForSeconds _ws;

    private void Awake()
    {
        _playerMemory = _player.GetComponent<PlayerMemory>();
        _ppippiStub = _stubObj.GetComponent<PpippiStub>();
        _playerColl = _player.GetComponent<CapsuleCollider2D>();
        _groundBoxColl = _groundColl.GetComponent<BoxCollider2D>();
        _ws = new WaitForSeconds(_showTime);

        // ���⼭ ������ �ʱ�ȭ�� ����
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
                    playerMemory._isMeetPpippi
                    );

        SaveData character = new SaveData(saveData);
        SaveSystem.Save(character, "Save" + GameDataPackage._index.ToString());
    }

    public void ApplyDataToGame()
    {
        // �ΰ��� ���� ��ҵ��� ���� �����Ϳ� ����� ������ �ٲ۴�.

        _playerMemory.transform.position = GameDataPackage._gameData._playerPos;            // �÷��̾��� ��ġ
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
            _ppippiStub._boxColl.enabled = false;
        }

        // �ΰ��� ������� �ε����� ������ ���� ����ȭ
        for (int i = 0; i < _memoryFragment.Length; i++)                
        {
            bool isActive = GameDataPackage._gameData._isFragIdxGet[i];
            _memoryFragment[i].SetActive(!isActive);
        }

        // ���� ��� ���� �������� �÷��̾� ���尪 ����, �ִϸ����� �Ҵ�
        if (ConstData._COLLECTLEVEL2 <= GameDataPackage._gameData._currCollectCount &&
            GameDataPackage._gameData._currCollectCount < ConstData._COLLECTLEVEL3)
        {
            // 2 ���� ĳ����
            _groundColl.transform.localPosition = new Vector3
                    (ConstData._LEVEL2_GROUND_COLL_TR_X,
                     ConstData._LEVEL2_GROUND_COLL_TR_Y,
                     _groundColl.transform.position.z);

            _groundBoxColl.size = new Vector2
                (ConstData._LEVEL2_GROUND_COLL_SIZE_X,
                 ConstData._LEVEL2_GROUND_COLL_SIZE_Y);

            _playerColl.offset = Vector2.zero;
            _playerColl.size = new Vector2(ConstData._LEVEL2_CAPSULE_COLL_SIZE_X, ConstData._LEVEL2_CAPSULE_COLL_SIZE_Y);
        }

        if (ConstData._COLLECTLEVEL3 <= GameDataPackage._gameData._currCollectCount)
        {
            // 3 ���� ĳ����
            _groundColl.transform.localPosition = new Vector3
                    (ConstData._LEVEL3_GROUND_COLL_TR_X,
                     ConstData._LEVEL3_GROUND_COLL_TR_Y,
                     _groundColl.transform.position.z);

            _groundBoxColl.size = new Vector2
                (ConstData._LEVEL3_GROUND_COLL_SIZE_X,
                 ConstData._LEVEL3_GROUND_COLL_SIZE_Y);

            _playerColl.offset = Vector2.zero;
            _playerColl.size = new Vector2(ConstData._LEVEL3_CAPSULE_COLL_SIZE_X, ConstData._LEVEL3_CAPSULE_COLL_SIZE_Y);
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
