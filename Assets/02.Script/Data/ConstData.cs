using UnityEngine;
using System;

static class ConstData
{
    public const int _TOTALMEMORYCOUNT = 6;
    public const int _SAVELISTCOUNT = 3;
    public const int _FIRST_SAVE_LIST_INDEX = 1;   // ����� ������ ���»��¿��� ���� ���۽� �ڵ����� ����Ǵ� ���̺� ����Ʈ�� �ε�����
    public const int _COLLECTLEVEL2 = 2;        // �÷��̾� ĳ������ ������ 2�� �����Ű�� ���� ��ƾ��ϴ� ������ ��
    public const int _COLLECTLEVEL3 = 4;        // �÷��̾� ĳ������ ������ 3���� �����Ű�� ���� ��ƾ��ϴ� ������ ��

    // ù ���� ���� ������
    public const float _INITPOSX = -12.017f;
    public const float _INITPOSY = 0.391f;
    public const float _INITPOSZ = 0.0f; 
    public const int _INITCOLLECTCOUNT = 0;

    // �÷��̾� ����1 ���� �ݶ��̴� ��
    public const float _LEVEL1_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL1_CAPSULE_COLL_SIZE_Y = 1.4f;
    public const float _LEVEL1_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL1_GROUND_COLL_TR_Y = -0.987f;
    public const float _LEVEL1_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL1_GROUND_COLL_SIZE_Y = 0.17f;
    public const float _LEVEL1_FOOT_POS = -0.64f;

    // �÷��̾� ����2 ���� �ݶ��̴� ��
    public const float _LEVEL2_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL2_CAPSULE_COLL_SIZE_Y = 1.59f;
    public const float _LEVEL2_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL2_GROUND_COLL_TR_Y = -0.987f;
    public const float _LEVEL2_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL2_GROUND_COLL_SIZE_Y = 0.17f;
    public const float _LEVEL2_FOOT_POS = -0.722f;

    // �÷��̾� ����3 ���� �ݶ��̴� ��
    public const float _LEVEL3_CAPSULE_COLL_SIZE_X = 1.1f;
    public const float _LEVEL3_CAPSULE_COLL_SIZE_Y = 2.17f;
    public const float _LEVEL3_GROUND_COLL_TR_X = 0.0f;
    public const float _LEVEL3_GROUND_COLL_TR_Y = -1.269f;
    public const float _LEVEL3_GROUND_COLL_SIZE_X = 1.0f;
    public const float _LEVEL3_GROUND_COLL_SIZE_Y = 0.17f;
    public const float _LEVEL3_FOOT_POS = -1.105f;

    public const string _isWatching = "��û ��";
    public const string _isNotWatching = "��û ���� ����";

    // �߻� �̺�Ʈ �ε��� ����, 1~6�� �޸� ������ �����ϰ�����
    // Little Girl
    public const string _LITTLEGIRL_EVENT_NAME = "�� �ٸ� ��ĵ� �� - 1";
    public const int _LITTLEGIRL_EVENT_IDX = 7;

    // Tall Boy
    public const string _TALLBOY_EVENT_NAME = "�� �ٸ� ��ĵ� �� - 2";
    public const int _TALLBOY_EVENT_IDX = 8;

    // Extra example
    public const string _EXTRACASE_EVENT_NAME = "�̺�Ʈ �� �Է�";
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
    public Vector3 _playerPos;                      // �÷��̾��� (x, y) ��ġ
    public string _nowTime;                         // ������ ��� ���� �ð�
    public bool[] _isFragIdxGet;                    // ȹ���� ��������� �ε���
    public int _currCollectCount;                   // ���� ���� ������ ��
    public int _newMemoryIdx;                       // �ֱ� ���� ��������� �ε���
    public bool _isEntryPlayTimeEnd;                // ���� ���� ù ������ �ô���
    public bool _isMeetPpippi;                      // �߻߿� ��������
    public bool[] _memoryPieceActive;               // �޸� ������ �ε��� ��°�� ��� ���� Ȱ��ȭ ����
    public ppippiEventData _newPpippiEvent;         // �� �߻� �̺�Ʈ
    public ppippiEventData[] _oldPpippiEvents;      // ���� �߻� �̺�Ʈ��

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