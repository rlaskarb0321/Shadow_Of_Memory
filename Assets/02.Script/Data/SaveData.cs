using System;
using UnityEngine;

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

    public SaveData(GameData gameData)
    {
        // �Ű������� �´ٸ�, �� ������ �ʱ�ȭ
        _gameData = gameData;
    }

    public SaveData()
    {
        // �Ű��������� �����Ǹ� �ʱⰪ���� ����
        _gameData = new GameData(
                new Vector3(ConstData._INITPOSX, ConstData._INITPOSY, ConstData._INITPOSZ), // ù��° �Ű�����
                new bool[ConstData._MEMORYCOUNT], // �ι�° �Ű�����
                ConstData._INITCOLLECTCOUNT); // ����° �Ű�����
    }
}
