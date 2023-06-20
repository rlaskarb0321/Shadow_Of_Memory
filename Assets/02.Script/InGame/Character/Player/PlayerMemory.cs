using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMemory : MonoBehaviour
{
    // SerializeField
    [SerializeField]
    private bool[] _isFragIdxGet;

    [SerializeField]
    private int _recentFragIdx; // �÷��̾ �ֱٿ� ȹ���� ��������� ��ȣ, �߻߿��� ���丮��ȭ�� ��û�ϸ� �ֱ� ȹ���� ������� ��ȣ��° ��ȭ�� ��µ�
    public int _playerCollectMemoryCount;

    [Header("=== Memory Board ===")] [SerializeField]
    private GameObject[] _memoryPuzzles;

    [SerializeField]
    private Text _acheivementRateText;

    [SerializeField]
    private Text _descriptionText;

    [SerializeField]
    private string[] _descriptionContent;

    // HideInInspector


    private void Start()
    {
        _acheivementRateText.text = "0 %";
        _descriptionText.text = "";
    }

    public void GetMemoryFragment(int index)
    {
        // ���� ����

        // ���� �� Player�� ó��
        _playerCollectMemoryCount++;
        _recentFragIdx = index;
        _isFragIdxGet[_recentFragIdx - 1] = true;

        // ���� �� MemoryBoard�� ó��
        _memoryPuzzles[_recentFragIdx - 1].gameObject.SetActive(true);
        _acheivementRateText.text = $"{(Mathf.Round((_playerCollectMemoryCount / 6.0f) * 100)) * 0.01f * 100} %";
    }

    // �޸� ���忡�ִ� ������ Ŭ���� �� 
    public void OnClickMemoryPuzzle(int index)
    {
        _descriptionText.text = _descriptionContent[index - 1];
    }

    public void OnClickStoryDialog()
    {
        if (_playerCollectMemoryCount == 0)
        {
            print("���� ������ ����� �����ϴ�");
            return;
        }

        print(_recentFragIdx + "�� ° ���丮 ��ȭ�� ���");
    }
}
