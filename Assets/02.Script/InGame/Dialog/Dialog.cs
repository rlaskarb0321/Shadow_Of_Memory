using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Text _context;
    [SerializeField] private Text _name;
    #region 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�
    //[SerializeField] private float _waitSeconds = 0.25f;
    #endregion 23.07.05 ��ȭ �ڷ�ƾ ��ü�ϱ�

    private string _fileName = "";
    private Dictionary<string, string> _csvDict; // Ÿ��Ʋ�� Ű�� �� ������ �и��� dict
    private DialogCSVReader _dialogCSV;
    private List<string> _header; // csv������ 0��° ����

    private List<string> _lines;
    private int _index;

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

        ShowDialog();
    }

    // gameObject.SetActive(true)�� ����� �� �ٷ� ����Ǵ� �Լ�
    // ��ȭ.csv ������ ������ "Ÿ��Ʋ" ������� �������� ���� dict���� �޾ƿ���, ����� ����Ʈ ���� �޾ƿ´�.
    public void SetDialogFile(string fileName)
    {
        if (_fileName.Equals(fileName))
            return;

        _fileName = fileName;
        _csvDict = _dialogCSV.GroupByTitle(fileName);
        _header = _dialogCSV.ReturnHeader(fileName);
        _lines = _csvDict["����"].Split("\r").ToList();
        _index = 0;

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
        string[] line = _lines[_index].Split(',');
        string jump = line[(int)Header.Jump];

        _context.text = line[(int)Header.Dialog];
        _name.text = line[(int)Header.Speaker];
        _index++;

        // �������� ���� ���� ������ Ÿ��Ʋ�� �����ؾ� �Ѵٴ� ��
        if (!jump.Equals(""))
        {
            _lines = _csvDict[jump].Split("\r").ToList();
            _index = 0;
        }
    }
}
