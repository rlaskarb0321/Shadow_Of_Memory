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
    public const float _LEVEL1_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL1_CAPSULE_COLL_SIZE_Y = 1.4f;
    public const float _LEVEL1_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL1_GROUND_COLL_TR_Y = -0.987f;
    public const float _LEVEL1_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL1_GROUND_COLL_SIZE_Y = 0.17f;

    // 플레이어 레벨2 관련 콜라이더 값
    public const float _LEVEL2_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL2_CAPSULE_COLL_SIZE_Y = 1.59f;
    public const float _LEVEL2_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL2_GROUND_COLL_TR_Y = -0.987f;
    public const float _LEVEL2_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL2_GROUND_COLL_SIZE_Y = 0.17f;

    // 플레이어 레벨3 관련 콜라이더 값
    public const float _LEVEL3_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL3_CAPSULE_COLL_SIZE_Y = 2.17f;
    public const float _LEVEL3_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL3_GROUND_COLL_TR_Y = -1.269f;
    public const float _LEVEL3_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL3_GROUND_COLL_SIZE_Y = 0.17f;
}

public struct PpippiEventData
{
    public string _name;
    public int _idx;
    public string _fileName;

    public PpippiEventData(string name, int idx, string fileName)
    {
        _name = name;
        _idx = idx;
        _fileName = fileName;
    }
}

[Serializable]
public struct GameData
{
    public Vector3 _playerPos;          // 플레이어의 (x, y) 위치
    public string _nowTime;             // 저장할 당시 현재 시간
    public bool[] _isFragIdxGet;        // 획득한 기억조각의 인덱스
    public int _currCollectCount;       // 현재 모은 조각의 수
    public int _newMemoryIdx;           // 최근 먹은 기억조각의 인덱스
    public bool _isEntryPlayTimeEnd;    // 게임 입장 첫 연출을 봤는지
    public bool _isMeetPpippi;          // 삐삐와 만났는지
    public bool[] _memoryPieceActive;   // 메모리 보드의 인덱스 번째의 기억 조각 활성화 여부

    public GameData(
        Vector3 playerPos, bool[] isFragIdxGet, int currCollectCount, int newMemoryIdx,
        bool isEntryPlayTimeEnd, bool isMeetPpippi, bool[] memoryPiecesActive)
    {
        _playerPos = playerPos;
        _nowTime = DateTime.Now.ToString("yy-MM-dd HH:mm");
        _isFragIdxGet = isFragIdxGet;
        _currCollectCount = currCollectCount;
        _newMemoryIdx = newMemoryIdx;
        _isEntryPlayTimeEnd = isEntryPlayTimeEnd;
        _isMeetPpippi = isMeetPpippi;
        _memoryPieceActive = memoryPiecesActive;
    }
}