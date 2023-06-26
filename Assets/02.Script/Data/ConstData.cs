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
    public Vector3 _playerPos; // �÷��̾��� (x, y) ��ġ
    public string _nowTime; // ������ ��� ���� �ð�
    public bool[] _isFragIdxGet; // ȹ���� ��������� �ε���
    public int _currCollectCount; // ���� ���� ������ ��

    public GameData(Vector3 playerPos, bool[] isFragIdxGet, int currCollectCount)
    {
        _playerPos = playerPos;
        _nowTime = DateTime.Now.ToString("yy-MM-dd HH:mm");
        _isFragIdxGet = isFragIdxGet;
        _currCollectCount = currCollectCount;
    }
}