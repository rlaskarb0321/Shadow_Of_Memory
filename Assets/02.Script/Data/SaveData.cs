using System;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    /*
    ������ ������

1 �÷��̾��� (x, y) ��ġ

2 ���� ���� ��Ȳ
2.1 �ʿ� �����ִ� �������� �ε���
2.2 ���� ���� ��Ȳ, �޸𸮺��� �޼���

3 �߻߿��� ��ȣ�ۿ�
3.1 �ֱپ��� ������� �ε���
3.2 �ֱپ��� ������� �ε����� ���� ��ȭ�� �ߴ��� ���ߴ���

4 �÷��̾��� ���� �ܰ�
4.1 ���� �ܰ迡 ���� �ݸ��� ũ�� ��Ÿ ���

5. �ƽ�
5.1 ���� �ƽ��� �ʱ� �����Ҷ����� ����. ������ �ҷ������� �� �� �ʿ�� ����
5.2 �߻� �ƽ��� ���� ���� �ķ� ������ ���� ���� �߻� Ȱ��ȭ ���ε� �����Ϳ� �߰�

6. �ֱ� ���� ��¥
6.1 ���������� ��¥

     */

    public GameData _gameData;
    public Vector3 _playerPos; // �÷��̾��� (x, y) ��ġ
    public string _nowTime; // ������ ��� ���� �ð�
    public bool[] _isFragIdxGet; // ȹ���� ��������� �ε���
    public int _currCollectCount; // ���� ���� ������ ��

    public SaveData(GameData gameData)
    {
        // �Ű������� �´ٸ�, �� ������ �ʱ�ȭ
        _gameData = gameData;

        _playerPos = gameData._playerPos;
        _nowTime = gameData._nowTime;
        _isFragIdxGet = gameData._isFragIdxGet;
        _currCollectCount = gameData._currCollectCount;
    }

    public SaveData()
    {
        // �Ű��������� �����Ǹ� �ʱⰪ���� ����
        _gameData = new GameData(Vector3.zero, new bool[ConstData._MEMORYCOUNT], 0);

        _playerPos = _gameData._playerPos;
        _nowTime = _gameData._nowTime;
        _isFragIdxGet = _gameData._isFragIdxGet;
        _currCollectCount = _gameData._currCollectCount;
    }
}
