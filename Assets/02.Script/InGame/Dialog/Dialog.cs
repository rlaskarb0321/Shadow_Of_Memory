using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Text _context;
    [SerializeField] private Text _name;
    #region 23.07.05 대화 코루틴 대체하기
    //[SerializeField] private float _waitSeconds = 0.25f;
    #endregion 23.07.05 대화 코루틴 대체하기

    private string _fileName = "";
    private Dictionary<string, string> _csvDict; // 타이틀을 키로 값 영역을 분리한 dict
    private DialogCSVReader _dialogCSV;
    private List<string> _header; // csv파일의 0번째 라인

    private List<string> _lines;
    private int _index;

    #region 23.07.05 대화 코루틴 대체하기
    //private List<string> _dictKeys; // 타이틀 값을 의미
    //private WaitUntil _waitUntil;
    //private WaitForSeconds _ws;
    //private string _newTitle;
    //private Coroutine _runCor = null;
    #endregion 23.07.05 대화 코루틴 대체하기

    enum Header { Title, Event, Speaker, Dialog, Jump };

    private void OnEnable()
    {
        #region 23.07.05 대화 코루틴 대체하기
        //if (_runCor != null)
        //{
        //    StopCoroutine(ReadDialogTitle(_newTitle));
        //    _runCor = StartCoroutine(ReadDialogTitle(_newTitle));
        //}
        #endregion 23.07.05 대화 코루틴 대체하기
        ProductionMgr._isPlayProduction = true;
    }

    private void OnDisable()
    {
        ProductionMgr._isPlayProduction = false;
    }

    private void Awake()
    {
        _dialogCSV = new DialogCSVReader();
        #region 23.07.05 대화 코루틴 대체하기
        //_waitUntil = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //_ws = new WaitForSeconds(_waitSeconds);
        #endregion 23.07.05 대화 코루틴 대체하기
    }

    private void Update()
    {
        if (_lines == null)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        ShowDialog();
    }

    // gameObject.SetActive(true)가 실행된 후 바로 실행되는 함수
    // 대화.csv 파일을 파일의 "타이틀" 헤더값을 기준으로 나눈 dict값을 받아오고, 헤더값 리스트 또한 받아온다.
    public void SetDialogFile(string fileName)
    {
        if (_fileName.Equals(fileName))
            return;

        _fileName = fileName;
        _csvDict = _dialogCSV.GroupByTitle(fileName);
        _header = _dialogCSV.ReturnHeader(fileName);
        _lines = _csvDict["시작"].Split("\r").ToList();
        _index = 0;

        ShowDialog();
        #region 23.07.05 대화 코루틴 대체하기
        //_dictKeys = _csvDict.Keys.ToList();
        //_runCor = StartCoroutine(ReadDialogTitle(_newTitle));
        //_newTitle = _dictKeys[0];
        #endregion 23.07.05 대화 코루틴 대체하기
    }

    #region 23.07.05 대화 코루틴 대체하기
    // 타이틀을 키 영역, 나머지를 값 영역으로 분리한 Dict의 타이틀값을 매개변수로 받는다.
    // 해당 매개변수의 데이터들을 파싱하고 ui에 표시까지 해준다.
    // 아직, 이벤트에 따른 분기점에 관한 내용은 하지않았음
    // 또한 title 값이 "끝"이면 끝내야함..
    //private IEnumerator ReadDialogTitle(string title)
    //{
    //    if (title.Equals("끝"))
    //    {
    //        print("끝");
    //        yield break;
    //    }

    //    string context; // 타이틀을 키로 받아온 값을 저장할 변수
    //    List<string> lines;
    //    int index;

    //    context = _csvDict[title];
    //    lines = context.Split("\r").ToList();
    //    //lines.RemoveAt(lines.Count - 1);
    //    index = 0;

    //    while (index < lines.Count)
    //    {
    //        string[] line = lines[index].Split(',');
    //        string dialogEvent = line[(int)Header.Event];
    //        if (!dialogEvent.Equals(""))
    //        {
    //            ActivateEvent(dialogEvent);
    //        }

    //        _name.text = line[(int)Header.Speaker];
    //        _context.text = line[(int)Header.Dialog];

    //        // 유저의 스페이스바 입력을 기다림
    //        yield return _waitUntil;
    //        _name.text = "";
    //        _context.text = "";

    //        string jump = line[(int)Header.Jump];
    //        if (!jump.Equals(""))
    //        {
    //            StopCoroutine(ReadDialogTitle(_newTitle));
    //            _runCor = StartCoroutine(ReadDialogTitle(jump));
    //            yield break;
    //        }

    //        index++;
    //        yield return _ws;
    //    }
    //}

    //private void ActivateEvent(string eventName)
    //{

    //}
    #endregion 23.07.05 대화 코루틴 대체하기

    private void ShowDialog()
    {
        string[] line = _lines[_index].Split(',');
        string jump = line[(int)Header.Jump];

        _context.text = line[(int)Header.Dialog];
        _name.text = line[(int)Header.Speaker];
        _index++;

        // 점프값과 같은 값을 가지는 타이틀로 점프해야 한다는 뜻
        if (!jump.Equals(""))
        {
            _lines = _csvDict[jump].Split("\r").ToList();
            _index = 0;
        }
    }
}
