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
                // /saves/Save_0n.json 이라는 파일의 존재에따라 (n = 1, 2, 3)
                // 저장된 데이터가 있다면 Overwrite, 없다면 Init Save

                SaveSystem.Save(new SaveData(Vector3.zero), fileName);
                LoadingScene.LoadScene("Campaign");
                break;

            case "SaveList":
                // /saves/Save_0n.json 이라는 파일의 존재에따라 (n = 1, 2, 3)
                // 저장된 데이터가 있다면 Load, 없다면 없다고 경고문띄우기
                break;
        }

    }
}
