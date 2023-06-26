using UnityEngine;
using System;

static class ConstData
{
    public const int _MEMORYCOUNT = 6;
    public const int _SAVELISTCOUNT = 3;
}

[Serializable]
public struct GameData
{
    public Vector3 _playerPos; // 플레이어의 (x, y) 위치
    public string _nowTime; // 저장할 당시 현재 시간
    public bool[] _isFragIdxGet; // 획득한 기억조각의 인덱스
    public int _currCollectCount; // 현재 모은 조각의 수

    public GameData(Vector3 playerPos, bool[] isFragIdxGet, int currCollectCount)
    {
        _playerPos = playerPos;
        _nowTime = DateTime.Now.ToString("yy-MM-dd HH:mm");
        _isFragIdxGet = isFragIdxGet;
        _currCollectCount = currCollectCount;
    }
}