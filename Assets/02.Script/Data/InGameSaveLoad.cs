using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캠페인 씬에 있는 스크립트
public class InGameSaveLoad : MonoBehaviour
{
    // SeriralizeField
    [Header("=== Extract List ===")]
    [SerializeField] private GameObject _player; // 플레이어
    [SerializeField] private GameObject _groundColl; // 플레이어 지면 닿음 관련 판정 콜리더
    [SerializeField] private GameObject _stubObj; // 삐삐가 앉아있던 그루터기
    [SerializeField] private GameObject _dummyPpippi; // 더미 삐삐
    [SerializeField] private GameObject _realPpippi; // 진짜 삐삐
    [SerializeField] private GameObject[] _memoryFragment; // 인 게임에 있는 기억 조각들

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

        // 여기서 데이터 초기화를 하자
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
        // 인게임 여러 요소들의 값을 데이터에 저장된 값으로 바꾼다.

        _playerMemory.transform.position = GameDataPackage._gameData._playerPos;            // 플레이어의 위치
        _playerMemory._isFragIdxGet = GameDataPackage._gameData._isFragIdxGet;              // 몇번째 인덱스의 기억조각을 먹었는지 아닌지
        _playerMemory._collectMemoryCount = GameDataPackage._gameData._currCollectCount;    // 현재 모은 기억 조각 개수
        _playerMemory._newMemoryIdx = GameDataPackage._gameData._newMemoryIdx;              // 새로 먹은 기억의 인덱스 값
        _playerMemory._isEntryPlayTimeEnd = GameDataPackage._gameData._isEntryPlayTimeEnd;  // 입장 컷신 봤는지
        _playerMemory._isMeetPpippi = GameDataPackage._gameData._isMeetPpippi;              // 그루터기에 앉아있던 삐삐와는 만났는지

        // 삐삐를 만났다면, 관련 게임Obj들의 값을 바꿔준다
        if (_playerMemory._isMeetPpippi)
        {
            _dummyPpippi.gameObject.SetActive(false);
            _realPpippi.gameObject.SetActive(true);
            _ppippiStub._boxColl.enabled = false;
        }

        // 인게임 기억조각 인덱스를 데이터 값과 동기화
        for (int i = 0; i < _memoryFragment.Length; i++)                
        {
            bool isActive = GameDataPackage._gameData._isFragIdxGet[i];
            _memoryFragment[i].SetActive(!isActive);
        }

        // 먹은 기억 조각 수에따라 플레이어 성장값 변경, 애니메이터 할당
        if (ConstData._COLLECTLEVEL2 <= GameDataPackage._gameData._currCollectCount &&
            GameDataPackage._gameData._currCollectCount < ConstData._COLLECTLEVEL3)
        {
            // 2 레벨 캐릭터
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
            // 3 레벨 캐릭터
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
