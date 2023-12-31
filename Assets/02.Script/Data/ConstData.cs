using UnityEngine;
using System;

static class ConstData
{
    public const int _TOTALMEMORYCOUNT = 6;
    public const int _SAVELISTCOUNT = 3;
    public const int _FIRST_SAVE_LIST_INDEX = 1;   // 저장된 게임이 없는상태에서 게임 시작시 자동으로 저장되는 세이브 리스트의 인덱스값
    public const int _COLLECTLEVEL2 = 2;        // 플레이어 캐릭터의 레벨을 2로 성장시키기 위해 모아야하는 조각의 수
    public const int _COLLECTLEVEL3 = 4;        // 플레이어 캐릭터의 레벨을 3으로 성장시키기 위해 모아야하는 조각의 수

    // 첫 저장 관련 데이터
    public const float _INITPOSX = -12.017f;
    public const float _INITPOSY = 0.391f;
    public const float _INITPOSZ = 0.0f; 
    public const int _INITCOLLECTCOUNT = 0;

    // 플레이어 레벨1 관련 콜라이더 값
    public const float _LEVEL1_CAPSULE_COLL_SIZE_X = 0.69f;
    public const float _LEVEL1_CAPSULE_COLL_SIZE_Y = 1.3f;
    public const float _LEVEL1_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL1_GROUND_COLL_TR_Y = -0.71f;
    public const float _LEVEL1_GROUND_COLL_SIZE_X = 0.58f;
    public const float _LEVEL1_GROUND_COLL_SIZE_Y = 0.11f;
    public const float _LEVEL1_FOOT_POS = -0.64f;

    // 플레이어 레벨2 관련 콜라이더 값
    public const float _LEVEL2_CAPSULE_COLL_SIZE_X = 0.69f;
    public const float _LEVEL2_CAPSULE_COLL_SIZE_Y = 1.59f;
    public const float _LEVEL2_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL2_GROUND_COLL_TR_Y = -0.845f;
    public const float _LEVEL2_GROUND_COLL_SIZE_X = 0.58f;
    public const float _LEVEL2_GROUND_COLL_SIZE_Y = 0.11f;
    public const float _LEVEL2_FOOT_POS = -0.722f;

    // 플레이어 레벨3 관련 콜라이더 값
    public const float _LEVEL3_CAPSULE_COLL_SIZE_X = 0.75f;
    public const float _LEVEL3_CAPSULE_COLL_SIZE_Y = 2.17f;
    public const float _LEVEL3_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL3_GROUND_COLL_TR_Y = -1.18f;
    public const float _LEVEL3_GROUND_COLL_SIZE_X = 0.58f;
    public const float _LEVEL3_GROUND_COLL_SIZE_Y = 0.11f;
    public const float _LEVEL3_FOOT_POS = -1.105f;

    public const string _isWatching = "시청 함";
    public const string _isNotWatching = "시청 하지 않음";

    // 삐삐 이벤트 인덱스 지정, 1~6은 메모리 조각이 차지하고있음
    // Little Girl
    public const string _LITTLEGIRL_EVENT_NAME = "또 다른 잠식된 자 - 1";
    public const int _LITTLEGIRL_EVENT_IDX = 7;

    // Tall Boy
    public const string _TALLBOY_EVENT_NAME = "또 다른 잠식된 자 - 2";
    public const int _TALLBOY_EVENT_IDX = 8;

    // Extra example
    public const string _EXTRACASE_EVENT_NAME = "이벤트 명 입력";
    public const int _EXTRACASE_EVENT_IDX = 9;
}

[Serializable]
public class ppippiEventData
{
    public string _name;
    public int _idx;
    public string _fileName;
    public bool _isWatching;

    public ppippiEventData(string name, int idx, string fileName, bool isWatching = false)
    {
        _name = name;
        _idx = idx;
        _fileName = fileName;
        _isWatching = isWatching;
    }
}

[Serializable]
public struct GameData
{
    public Vector3 _playerPos;                      // 플레이어의 (x, y) 위치
    public string _nowTime;                         // 저장할 당시 현재 시간
    public bool[] _isFragIdxGet;                    // 획득한 기억조각의 인덱스
    public int _currCollectCount;                   // 현재 모은 조각의 수
    public int _newMemoryIdx;                       // 최근 먹은 기억조각의 인덱스
    public bool _isEntryPlayTimeEnd;                // 게임 입장 첫 연출을 봤는지
    public bool _isMeetPpippi;                      // 삐삐와 만났는지
    public bool[] _memoryPieceActive;               // 메모리 보드의 인덱스 번째의 기억 조각 활성화 여부
    public ppippiEventData _newPpippiEvent;         // 새 삐삐 이벤트
    public ppippiEventData[] _oldPpippiEvents;      // 이전 삐삐 이벤트들

    public GameData(Vector3 playerPos, bool[] isFragIdxGet, int currCollectCount, int newMemoryIdx,
        bool isEntryPlayTimeEnd, bool isMeetPpippi, bool[] memoryPiecesActive, ppippiEventData newPpippiEvent,
        ppippiEventData[] oldPpippiEvents)
    {
        _playerPos = playerPos;
        _nowTime = DateTime.Now.ToString("yy-MM-dd HH:mm");
        _isFragIdxGet = isFragIdxGet;
        _currCollectCount = currCollectCount;
        _newMemoryIdx = newMemoryIdx;
        _isEntryPlayTimeEnd = isEntryPlayTimeEnd;
        _isMeetPpippi = isMeetPpippi;
        _memoryPieceActive = memoryPiecesActive;
        _newPpippiEvent = newPpippiEvent;
        _oldPpippiEvents = oldPpippiEvents;
    }
}