using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Text _context;
    [SerializeField] private Text _name;
    [SerializeField] private float _waitSeconds = 0.5f;

    private string _fileName = "";
    private Dictionary<string, string> _csvDict;
    private DialogCSVReader _dialogCSV;
    private List<string> _header;
    private List<string> _dictKeys;
    private WaitUntil _waitUntil;
    private WaitForSeconds _ws;
    private string _newTitle;
    private Coroutine _runCor = null;

    private void OnEnable()
    {
        if (_runCor != null)
        {
            StopCoroutine(ReadDialogTitle(_newTitle));
            _runCor = StartCoroutine(ReadDialogTitle(_newTitle));
        }
        ProductionMgr._isPlayProduction = true;
    }

    private void OnDisable()
    {
        ProductionMgr._isPlayProduction = false;
    }

    private void Awake()
    {
        _dialogCSV = new DialogCSVReader();
        _waitUntil = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        _ws = new WaitForSeconds(_waitSeconds);
    }

    public void SetDialogFile(string fileName)
    {
        if (_fileName.Equals(fileName))
            return;

        _fileName = fileName;
        _csvDict = _dialogCSV.GroupByTitle(fileName);
        _header = _dialogCSV.ReturnHeader(fileName);
        _dictKeys = _csvDict.Keys.ToList();
        _newTitle = _dictKeys[0];

        _runCor = StartCoroutine(ReadDialogTitle(_newTitle));
    }

    // Ÿ��Ʋ�� Ű ����, �������� �� �������� �и��� Dict�� Ÿ��Ʋ���� �Ű������� �޴´�.
    // �ش� �Ű������� �����͵��� �Ľ��ϰ� ui�� ǥ�ñ��� ���ش�.
    // ����, �̺�Ʈ�� ���� �б����� ���� ������ �����ʾ���
    // ���� title ���� "��"�̸� ��������..
    private IEnumerator ReadDialogTitle(string title)
    {
        string context;
        List<string> lines;
        int index;
        int speakerIdx;
        int dialogIdx;

        context = _csvDict[title];
        lines = context.Split("\r").ToList();
        lines.RemoveAt(lines.Count - 1);
        index = 0;
        speakerIdx = _header.IndexOf("�̸�");
        dialogIdx = _header.IndexOf("���");

        while (index < lines.Count)
        {
            string[] line = lines[index].Split(',');
            string speaker = line[speakerIdx];
            string dialog = line[dialogIdx];

            _name.text = speaker;
            _context.text = dialog;

            yield return _waitUntil;

            _name.text = "";
            _context.text = "";
            index++;

            yield return _ws;
        }
    }
}
