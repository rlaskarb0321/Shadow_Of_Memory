using UnityEngine;
using System;

static class ConstData
{
    public const int _TOTALMEMORYCOUNT = 6;
    public const int _SAVELISTCOUNT = 3;
    public const int _FIRSTSAVELISTINDEX = 1;   // 저장된 게임이 없는상태에서 게임 시작시 자동으로 저장되는 세이브 리스트의 인덱스값
    public const int _COLLECTLEVEL2 = 2;        // 플레이어 캐릭터의 레벨을 2로 성장시키기 위해 모아야하는 조각의 수
    public const int _COLLECTLEVEL3 = 4;        // 플레이어 캐릭터의 레벨을 3으로 성장시키기 위해 모아야하는 조각의 수

    // 첫 저장 관련 데이터
    public const float _INITPOSX = -12.017f;
    public const float _INITPOSY = 0.391f;
    public const float _INITPOSZ = 0.0f; 
    public const int _INITCOLLECTCOUNT = 0; 
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

    public GameData
        (Vector3 playerPos, bool[] isFragIdxGet, int currCollectCount, int newMemoryIdx, bool isEntryPlayTimeEnd, bool isMeetPpippi)
    {
        _playerPos = playerPos;
        _nowTime = DateTime.Now.ToString("yy-MM-dd HH:mm");
        _isFragIdxGet = isFragIdxGet;
        _currCollectCount = currCollectCount;
        _newMemoryIdx = newMemoryIdx;
        _isEntryPlayTimeEnd = isEntryPlayTimeEnd;
        _isMeetPpippi = isMeetPpippi;
    }
}