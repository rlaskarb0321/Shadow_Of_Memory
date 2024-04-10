using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dialog : MonoBehaviour
{
    [SerializeField] private CampaignUI _campaignUI;
    [SerializeField] private GameObject _dialogOption;
    [SerializeField] private GameObject _answerOption;
    [SerializeField] private Text _name;

    [Header("=== dialog ===")]
    [SerializeField] private Text _context;
    [SerializeField] private AudioClip _chatSelectChageSound;

    [Header("=== Answer ===")]
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _answerPrefab;

    private string _fileName = "";
    private Dictionary<string, string> _csvDict; // 타이틀을 키로 값 영역을 분리한 dict
    private DialogCSVReader _dialogCSV;
    private List<string> _header; // csv파일의 0번째 라인

    private DialogEvent _dialogEvent;
    private List<string> _lines; // 타이틀을 키값으로 접근해 _csvDict의 값 영역을 가져와 저장할 변수
    private int _index;
    private string _currTitle;
    private AudioSource _audio;

    enum Header { Title, Event, Speaker, Dialog, Jump };

    private void OnEnable()
    {
        ProductionMgr._isPlayProduction = true;
    }

    private void OnDisable()
    {
        ProductionMgr._isPlayProduction = false;
    }

    private void Awake()
    {
        _dialogCSV = new DialogCSVReader();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_answerOption.activeSelf && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            OnChangeAnswerSelect();
        }

        if (_lines == null)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        switch (_currTitle)
        {
            case "선택지":
                ShowBifurDialog();
                break;

            case "끝":
                EndDialog();
                break;

            default:
                ShowDialog();
                break;
        }
    }

    // gameObject.SetActive(true)가 실행된 후 바로 실행되는 함수
    // 대화.csv 파일을 파일의 "타이틀" 헤더값을 기준으로 나눈 dict값을 받아오고, 헤더값 리스트 또한 받아온다.
    // 대화 시스템을 시작한다.
    public void SetDialogFile(string fileName, DialogEvent dialogEvent = null)
    {
        _dialogEvent = dialogEvent;
        if (!_fileName.Equals(fileName))
        {
            _fileName = fileName;
            _csvDict = _dialogCSV.GroupByTitle(fileName);
            _header = _dialogCSV.ReturnHeader(fileName);
        }

        JumpToTitle("시작");
        ShowDialog();
    }

    // 대화를 보여주는 함수
    private void ShowDialog()
    {
        if (!_dialogOption.activeSelf)
            _dialogOption.SetActive(true);

        if (_answerOption.activeSelf)
            _answerOption.SetActive(false);

        string[] line = _lines[_index].Split(',');
        string jump = line[(int)Header.Jump];
        string dialogEvent = line[(int)Header.Event];

        _context.text = line[(int)Header.Dialog];
        _name.text = line[(int)Header.Speaker];
        _index++;

        if (_dialogEvent != null && !dialogEvent.Equals(""))
        {
            _dialogEvent.DoDialogEvent(dialogEvent);
        }

        if (!jump.Equals(""))
        {
            JumpToTitle(jump);
        }
    }

    // 대화가 끝날때 실행되는 함수
    private void EndDialog()
    {
        // _dialogEvent._isDialog = false;
        _campaignUI.SetDialogOn(false, "", _dialogEvent);
    }

    // 선택지 항목 보여주기
    private void ShowBifurDialog()
    {
        if (!_answerOption.activeSelf)
            _answerOption.SetActive(true);

        if (_dialogOption.activeSelf)
            _dialogOption.SetActive(false);

        string[] line = _lines[_index].Split(',');
        _name.text = line[(int)Header.Speaker];

        for (_index = 0; _index < _lines.Count; _index++)
        {
            int temp = _index;

            line = _lines[temp].Split(',');
            string answer = line[(int)Header.Dialog];
            string jump = line[(int)Header.Jump];
            Button answerBtn = _content.transform.GetChild(temp).GetComponent<Button>();
            if (!answerBtn.gameObject.activeSelf)
            {
                answerBtn.gameObject.SetActive(true);
            }
            else
            {
                answerBtn.gameObject.SetActive(false);
                answerBtn.gameObject.SetActive(true);
            }

            if (temp.Equals(0))
                answerBtn.Select();

            answerBtn.onClick.RemoveAllListeners(); // 이걸 해 줘야 이전 대화.csv의 선택지 점프조건으로 점프를 하지 않는다
            answerBtn.onClick.AddListener(() => JumpToTitle(jump));
            answerBtn.onClick.AddListener(() => IsClickAnswer());

            answerBtn.transform.GetChild(0).GetComponent<Text>().text = answer;
        }
    }

    // 타이틀 값에 맞는 대화 본문을 가져옴
    private void JumpToTitle(string title)
    {
        _lines = _csvDict[title].TrimEnd('\r').Split("\r").ToList();
        _currTitle = title.Split(" ")[0];
        _index = 0;
    }

    private void IsClickAnswer()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ShowDialog();
        }
    }

    private void OnChangeAnswerSelect()
    {
        if (_chatSelectChageSound != null)
        {
            _audio.PlayOneShot(_chatSelectChageSound, 0.8f);
        }
    }
}
