using UnityEngine;
using System;

static class ConstData
{
    public const int _TOTALMEMORYCOUNT = 6;
    public const int _SAVELISTCOUNT = 3;
    public const int _FIRSTSAVELISTINDEX = 1;   // ����� ������ ���»��¿��� ���� ���۽� �ڵ����� ����Ǵ� ���̺� ����Ʈ�� �ε�����
    public const int _COLLECTLEVEL2 = 2;        // �÷��̾� ĳ������ ������ 2�� �����Ű�� ���� ��ƾ��ϴ� ������ ��
    public const int _COLLECTLEVEL3 = 4;        // �÷��̾� ĳ������ ������ 3���� �����Ű�� ���� ��ƾ��ϴ� ������ ��

    // ù ���� ���� ������
    public const float _INITPOSX = -12.017f;
    public const float _INITPOSY = 0.391f;
    public const float _INITPOSZ = 0.0f; 
    public const int _INITCOLLECTCOUNT = 0; 
}

[Serializable]
public struct GameData
{
    public Vector3 _playerPos;          // �÷��̾��� (x, y) ��ġ
    public string _nowTime;             // ������ ��� ���� �ð�
    public bool[] _isFragIdxGet;        // ȹ���� ��������� �ε���
    public int _currCollectCount;       // ���� ���� ������ ��
    public int _newMemoryIdx;           // �ֱ� ���� ��������� �ε���
    public bool _isEntryPlayTimeEnd;    // ���� ���� ù ������ �ô���
    public bool _isMeetPpippi;          // �߻߿� ��������

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