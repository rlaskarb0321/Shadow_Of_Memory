using System;
using UnityEngine;

public class SaveData
{
    /*
    ������ ������

1 �÷��̾��� (x, y) ��ġ -> Vector3 _playerPos;

2 ���� ���� ��Ȳ
2.1 �ʿ� �����ִ� �������� �ε��� -> bool[] _isFragIdxGet;
2.2 ���� ���� ��Ȳ, �޸𸮺��� �޼��� -> int _currCollectCount; ,  _currCollectCount / _TOTALMEMORYCOUNT;

3 �߻߿��� ��ȣ�ۿ�
3.1 �ֱپ��� ������� �ε��� -> int _recentFragIdx
3.2 �ֱپ��� ������� �ε����� ���� ��ȭ�� �ߴ��� ���ߴ���

4 �÷��̾��� ���� �ܰ�
4.1 ���� �ܰ迡 ���� capsule 2d �ݸ����� size �� -> ok
4.2 ���� �ܰ迡 ���� grounded coll �� transform �� size -> ok

5. �ƽ�
5.1 ���� �ƽ��� �ʱ� �����Ҷ����� ����. ������ �ҷ������� �� �� �ʿ�� ���� -> bool _isFirstEnter;
5.2 �߻� �ƽ��� ���� ���� �ķ� ������ ���� ���� �߻� Ȱ��ȭ ���ε� �����Ϳ� �߰� -> bool _isMeetPpippi;

6. �ֱ� ���� ��¥
6.1 ���������� ��¥ -> string _nowTime;

7. �߻� �̺�Ʈ ����Ʈ : ���� ���� ��, �ҷ��ö� GObj�� ������Ű�� ���� �����Ű��
7.1 ���� ����Ʈ �׸�
7.2 �õ� ����Ʈ �׸�

     */

    public GameData _gameData;

    public SaveData(GameData gameData)
    {
        // �Ű������� �´ٸ�, �� ������ �ʱ�ȭ
        _gameData = gameData;
    }

    public SaveData()
    {
        // �Ű��������� �����Ǹ� �ʱⰪ���� ����
        _gameData = new GameData(
                new Vector3(ConstData._INITPOSX, ConstData._INITPOSY, ConstData._INITPOSZ), // �Ű����� 1 -> �÷��̾� ��ġ
                new bool[ConstData._TOTALMEMORYCOUNT],                                      // �Ű����� 2 -> ������� �ε����� ȹ�� ����
                ConstData._INITCOLLECTCOUNT,                                                // �Ű����� 3 -> ���� ���� ���� ��
                0,                                                                          // �Ű����� 4 -> ���θ��� ������ �ε���
                false,                                                                      // �Ű����� 5 -> �����ƽ� �� �ô���
                false,                                                                      // �Ű����� 6 -> �߻߶� ��������    
                new bool[ConstData._TOTALMEMORYCOUNT],                                      // �Ű����� 7 -> �޸� ������ �ε����� Ȱ��ȭ ����
                null,                                                                       // �Ű����� 8 -> �� �߻� �̺�Ʈ
                null);                                                                      // �Ű����� 9 -> ���� �߻� �̺�Ʈ��
    }
}
