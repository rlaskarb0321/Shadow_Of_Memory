using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMemory : MonoBehaviour
{
    // SerializeField
    [Header("=== Memory Frament ===")] 
    public bool[] _isFragIdxGet; // �ε�����°�� ����� ���� ���θ� ����
    public int _newMemoryIdx; // �÷��̾ �ֱٿ� ȹ���� ��������� ��ȣ, �߻߿��� ���丮��ȭ�� ��û�ϸ� �ֱ� ȹ���� ������� ��ȣ��° ��ȭ�� ��µ�
    public int _collectMemoryCount; // �� ���� ����� ��

    [Header("=== Memory Board ===")] 
    [SerializeField] private GameObject[] _memoryPuzzles; // ��������
    [SerializeField] private Text _currCollectText; // ���� ���� ��
    [SerializeField] private Text _acheiveRateText; // �޼����� ǥ���ϴ� �ؽ�Ʈ
    [SerializeField] private Text _descriptionText; // Ȱ��ȭ�� ����� Ŭ�������� ���� ������ ǥ���� �ؽ�Ʈ
    [SerializeField] private string[] _descriptionContent; // ��� ���� ������ ����

    [Header("=== Black Cloud Note ===")]
    [SerializeField] private Image _memoryImage; // ������ ��������� �̹���
    [SerializeField] private GameObject _blackCloudNote; // ������������� ����
    [SerializeField] private Text _blackCloudTitle; // ������ ����
    [SerializeField] private Text _blackCloudContext; // ������ ����

    // HideInInspector
    // private type _filedName;

    private void Start()
    {
        _acheiveRateText.text = "0 %";
        _descriptionText.text = "";
    }

    public void GetMemoryFragment(int index, Sprite memoryImage)
    {
        _memoryImage.sprite = memoryImage;
        _memoryImage.SetNativeSize();

        // ���� ����

        // ���� �� Player�� ó��
        CountMemoryFragment(index);

        // ���� �� MemoryBoard�� ó��
        UpdateMemoryBoard(index);

        // ��������
        ShowBlackCloudNote(index);
    }

    // �޸� ���忡�ִ� ������ Ŭ���� �� 
    public void OnClickMemoryPuzzle(int index)
    {
        _descriptionText.text = _descriptionContent[index - 1];
    }

    // �߻߿��� ��ȣ�ۿ� ��ȭ���� ������ �������� ����� ��
    public void OnClickStoryDialog()
    {
        if (_collectMemoryCount == 0)
        {
            print("���� ������ ����� �����ϴ�");
            return;
        }

        print(_newMemoryIdx + "�� ° ���丮 ��ȭ�� ���");
    }

    private void CountMemoryFragment(int index)
    {
        // ���� ������ +1
        _collectMemoryCount++;

        // �ֱ� ���� ����� �ε����� ����, �ش� ������ �ε����� ����ó��
        _newMemoryIdx = index;
        _isFragIdxGet[index - 1] = true;

        if (_collectMemoryCount == 6)
        {
            print("�� ��Ҵ�.");
        }
    }

    private void UpdateMemoryBoard(int index)
    {
        // ���� ������� �̹��� Ȱ��ȭ
        _memoryPuzzles[index - 1].gameObject.SetActive(true);

        // �޼����� ���൵ �ֽ�ȭ
        _acheiveRateText.text = $"{(Mathf.Round((_collectMemoryCount / 6.0f) * 100)) * 0.01f * 100} %";
        _currCollectText.text = _collectMemoryCount.ToString();
    }

    private void ShowBlackCloudNote(int index)
    {
        // �������� string���� ����, �������� ���� ����
        string[] contextLine = _descriptionContent[index - 1].Split('\\');
        string title = contextLine[0];
        string context = contextLine[1];

        if (_blackCloudNote.activeSelf)
            _blackCloudNote.SetActive(false);

        _blackCloudNote.SetActive(true);
        _blackCloudTitle.text = title;
        _blackCloudContext.text = context;
    }
}
