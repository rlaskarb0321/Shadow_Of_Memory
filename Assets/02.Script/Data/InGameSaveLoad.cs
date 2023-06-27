using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캠페인 씬에 있는 스크립트
public class InGameSaveLoad : MonoBehaviour
{
    // SeriralizeField
    [Header("=== Extract List ===")]
    [SerializeField] private GameObject _player;

    [Header("=== Game Data ===")]
    public GameData _data; // 사실 또 하나의 변수를 낼 필요는없는데 일단 디버깅을 편하게 하기위해 만들었음

    // HideInInspector
    private PlayerMemory _playerMemory;

    private void Awake()
    {
        _data = GameDataPackage._gameData; 
        _playerMemory = _player.GetComponent<PlayerMemory>();

        // 여기서 데이터 초기화를 하자
        _playerMemory.transform.position = _data._playerPos;
        _playerMemory._isFragIdxGet = _data._isFragIdxGet;
        _playerMemory._collectMemoryCount = _data._currCollectCount;
        _playerMemory._newMemoryIdx = _data._newMemoryIdx;
        _playerMemory._isEntryPlayTimeEnd = _data._isEntryPlayTimeEnd;
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
                    _playerMemory._isEntryPlayTimeEnd
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

}
