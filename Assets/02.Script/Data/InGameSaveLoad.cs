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
    [SerializeField] private GameObject[] _memoryFragment;

    [Header("=== Game Data ===")]
    public GameData _data; // ��� �� �ϳ��� ������ �� �ʿ�¾��µ� �ϴ� ������� ���ϰ� �ϱ����� �������

    // HideInInspector
    private PlayerMemory _playerMemory;
    private PpippiStub _ppippiStub;

    private void Awake()
    {
        _data = GameDataPackage._gameData; 
        _playerMemory = _player.GetComponent<PlayerMemory>();
        _ppippiStub = _stubObj.GetComponent<PpippiStub>();

        // ���⼭ ������ �ʱ�ȭ�� ����
        ApplyDataToGame();
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            GameData saveData =
                new GameData(
                    _playerMemory.transform.position,
                    _playerMemory._isFragIdxGet,
                    _playerMemory._collectMemoryCount,
                    _playerMemory._newMemoryIdx,
                    _playerMemory._isEntryPlayTimeEnd,
                    _playerMemory._isMeetPpippi
                    );
            SaveData character = new SaveData(saveData);
            _data = saveData; 

            SaveSystem.Save(character, "Save" + GameDataPackage._index.ToString());
        }

        //if (Input.GetKeyDown("l"))
        //{
        //    SaveData loadData = SaveSystem.Load("Save1");
        //    print("Load Success");
        //}
    }

    public void ApplyDataToGame()
    {
        // �ΰ��� ���� ��ҵ��� ���� �����Ϳ� ����� ������ �ٲ۴�.

        _playerMemory.transform.position = _data._playerPos;            // �÷��̾��� ��ġ
        _playerMemory._isFragIdxGet = _data._isFragIdxGet;              // ���° �ε����� ��������� �Ծ����� �ƴ���
        _playerMemory._collectMemoryCount = _data._currCollectCount;    // ���� ���� ��� ���� ����
        _playerMemory._newMemoryIdx = _data._newMemoryIdx;              // ���� ���� ����� �ε��� ��
        _playerMemory._isEntryPlayTimeEnd = _data._isEntryPlayTimeEnd;  // ���� �ƽ� �ô���
        _playerMemory._isMeetPpippi = _data._isMeetPpippi;              // �׷��ͱ⿡ �ɾ��ִ� �߻߿ʹ� ��������

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
            bool isActive = _data._isFragIdxGet[i];
            _memoryFragment[i].SetActive(isActive);
        }

        // ���� ��� ���� �������� �÷��̾� ���尪 ����
        if (_data._currCollectCount < ConstData._COLLECTLEVEL2)
        {
            // 1 ���� ĳ����
        }
        else if (_data._currCollectCount < ConstData._COLLECTLEVEL3)
        {
            // 2 ���� ĳ����
        }
        else
        {
            // 3 ���� ĳ����
        }
    }
}
