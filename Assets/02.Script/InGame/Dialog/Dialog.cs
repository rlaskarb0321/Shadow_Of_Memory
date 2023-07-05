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

    // 타이틀을 키 영역, 나머지를 값 영역으로 분리한 Dict의 타이틀값을 매개변수로 받는다.
    // 해당 매개변수의 데이터들을 파싱하고 ui에 표시까지 해준다.
    // 아직, 이벤트에 따른 분기점에 관한 내용은 하지않았음
    // 또한 title 값이 "끝"이면 끝내야함..
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
        speakerIdx = _header.IndexOf("이름");
        dialogIdx = _header.IndexOf("대사");

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
