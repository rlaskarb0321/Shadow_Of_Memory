using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Events")]
    public int _collectFragCount; // ó��ȹ���, �� �� ������������ŭ ȹ���
    public bool _firstExp; // ó�� �����
    public bool _firstEneryCube; // ������ ť�� ó�� ��ȣ�ۿ� ��

    [Space(12.0f)]
    public string[] _firstExpDialogues; // ù ����� ��� ���
    public string[] _fragDialogues; // ������� ��ȣ�ۿ� ��� ���
    
    [Space(12.0f)]
    public string[] _energyCubeDialogues; // ������ ť�� ��ȣ�ۿ� ��� ���
    public string[] _trapDialogues; // ����(����) ��ȣ�ۿ� ���
}
    