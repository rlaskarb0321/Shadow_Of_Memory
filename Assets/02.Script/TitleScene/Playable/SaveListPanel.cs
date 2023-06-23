using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;

public class SaveListPanel : MonoBehaviour
{
    private string _pathName;

    public void SetPath(string name)
    {
        _pathName = name;
    }

    public void OnSaveListClick(int index)
    {
        string fileName = "Save" + index.ToString();

        switch (_pathName)
        {
            case "NewGame":
                // /saves/Save_0n.json �̶�� ������ ���翡���� (n = 1, 2, 3)
                // ����� �����Ͱ� �ִٸ� Overwrite, ���ٸ� Init Save

                SaveSystem.Save(new SaveData(Vector3.zero), fileName);
                LoadingScene.LoadScene("Campaign");
                break;

            case "SaveList":
                // /saves/Save_0n.json �̶�� ������ ���翡���� (n = 1, 2, 3)
                // ����� �����Ͱ� �ִٸ� Load, ���ٸ� ���ٰ� �������
                break;
        }

    }
}
