using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private string _fileName;
    private Dictionary<string, string> _csvDict;
    private CSVReader _csvReader;

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
        _csvReader = new CSVReader();
    }

    public void SetDialogFile(string fileName)
    {
        if (_fileName.Equals(fileName))
            return;

        _fileName = fileName;
        _csvDict = _csvReader.Parsing(fileName);
    }
}
