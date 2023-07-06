using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private CampaignUI _campaignUI;
    [SerializeField] private GameObject _dialogOption;
    [SerializeField] private GameObject _answerOption;
    [SerializeField] private Text _name;

    [Header("=== dialog ===")]
    [SerializeField] private Text _context;
    #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    //[SerializeField] private float _waitSeconds = 0.25f;
    #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�

    private string _fileName = "";
    private Dictionary<string, string> _csvDict; // Ÿ��Ʋ�� Ű�� �� ������ �и��� dict
    private DialogCSVReader _dialogCSV;
    private List<string> _header; // csv������ 0��° ����

    private List<string> _lines;
    private int _index;
    private string _currTitle;

    #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    //private List<string> _dictKeys; // Ÿ��Ʋ ���� �ǹ�
    //private WaitUntil _waitUntil;
    //private WaitForSeconds _ws;
    //private string _newTitle;
    //private Coroutine _runCor = null;
    #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�

    enum Header { Title, Event, Speaker, Dialog, Jump };

    private void OnEnable()
    {
        #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
        //if (_runCor != null)
        //{
        //    StopCoroutine(ReadDialogTitle(_newTitle));
        //    _runCor = StartCoroutine(ReadDialogTitle(_newTitle));
        //}
        #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
        ProductionMgr._isPlayProduction = true;
    }

    private void OnDisable()
    {
        ProductionMgr._isPlayProduction = false;
    }

    private void Awake()
    {
        _dialogCSV = new DialogCSVReader();
        #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
        //_waitUntil = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //_ws = new WaitForSeconds(_waitSeconds);
        #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    }

    private void Update()
    {
        if (_lines == null)
            return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        switch (_currTitle)
        {
            case "������":
                ShowBifurDialog();
                break;

            case "��":
                EndDialog();
                break;

            default:
                ShowDialog();
                break;
        }
    }

    // gameObject.SetActive(true)�� ����� �� �ٷ� ����Ǵ� �Լ�
    // ��ȭ.csv ������ ������ "Ÿ��Ʋ" ������� �������� ���� dict���� �޾ƿ���, ����� ����Ʈ ���� �޾ƿ´�.
    public void SetDialogFile(string fileName)
    {
        if (!_fileName.Equals(fileName))
        {
            _fileName = fileName;
            _csvDict = _dialogCSV.GroupByTitle(fileName);
            _header = _dialogCSV.ReturnHeader(fileName);
        }

        JumpToTitle("����");
        ShowDialog();
        #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
        //_dictKeys = _csvDict.Keys.ToList();
        //_runCor = StartCoroutine(ReadDialogTitle(_newTitle));
        //_newTitle = _dictKeys[0];
        #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    }

    #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    // Ÿ��Ʋ�� Ű ����, �������� �� �������� �и��� Dict�� Ÿ��Ʋ���� �Ű������� �޴´�.
    // �ش� �Ű������� �����͵��� �Ľ��ϰ� ui�� ǥ�ñ��� ���ش�.
    // ����, �̺�Ʈ�� ���� �б����� ���� ������ �����ʾ���
    // ���� title ���� "��"�̸� ��������..
    //private IEnumerator ReadDialogTitle(string title)
    //{
    //    if (title.Equals("��"))
    //    {
    //        print("��");
    //        yield break;
    //    }

    //    string context; // Ÿ��Ʋ�� Ű�� �޾ƿ� ���� ������ ����
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

    //        // ������ �����̽��� �Է��� ��ٸ�
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
    #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�

    private void ShowDialog()
    {
        if (!_dialogOption.activeSelf)
            _dialogOption.SetActive(true);

        if (_answerOption.activeSelf)
            _answerOption.SetActive(false);

        string[] line = _lines[_index].Split(',');
        string jump = line[(int)Header.Jump];

        _context.text = line[(int)Header.Dialog];
        _name.text = line[(int)Header.Speaker];
        _index++;

        if (!jump.Equals(""))
        {
            JumpToTitle(jump);
        }
    }

    private void EndDialog()
    {
        JumpToTitle("����");
        _campaignUI.SetDialogOn(false);
    }

    private void ShowBifurDialog()
    {
        if (!_answerOption.activeSelf)
            _answerOption.SetActive(true);

        if (_dialogOption.activeSelf)
            _dialogOption.SetActive(false);

        for (_index = 0; _index < _lines.Count; _index++)
        {
            string[] line = _lines[_index].Split(',');
            //print(line[(int)Header.Speaker] + " : " + line[(int)Header.Dialog]);
        }
    }

    // Ÿ��Ʋ ���� �´� ��ȭ ������ ������
    public void JumpToTitle(string title)
    {
        _lines = _csvDict[title].TrimEnd('\r').Split("\r").ToList();
        _currTitle = title.Split(" ")[0];
        _index = 0;
    }
}
