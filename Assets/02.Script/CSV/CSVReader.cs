using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class CSVReader
{
    private char[] trim_char = new char[] { ',', ' ' };

    public Dictionary<string, string> Parsing(string fileName)
    {
        Dictionary<string, string> dict;
        TextAsset textAsset;
        string[] lines;
        string title;
        StringBuilder sb;

        sb = new StringBuilder();
        title = "";
        dict = new Dictionary<string, string>();
        textAsset = Resources.Load(fileName) as TextAsset;
        lines = textAsset.text.Split('\n');

        // Ÿ��Ʋ �� ���� �ٺ��� ���빰�� �´� Ÿ��Ʋ���� �и���Ű��
        for (int i = 1; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(',');

            // Ÿ��Ʋ���� �ִ�
            if (!line[0].Equals(""))
            {
                // ���� title���� �����ϸ�
                if (!title.Equals(""))
                {
                    // sb�� �׾Ƶ� ������ "�� title�� == ��ųʸ� Ű" �� �� value�� �߰�
                    string context = sb.ToString();
                    dict[title] = context;
                }

                // �� Ÿ��Ʋ�� ����
                title = line[0].Trim(trim_char);
                dict.Add(title, "");
                sb.Clear();
                continue;
            }

            sb.Append(lines[i]);
        }

        return dict;
    }
}
