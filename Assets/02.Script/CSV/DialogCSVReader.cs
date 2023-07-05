using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class DialogCSVReader
{
    private char[] trim_char = new char[] { ',', ' ' };

    public Dictionary<string, string> GroupByTitle(string fileName)
    {
        Dictionary<string, string> dict;
        TextAsset textAsset;
        string[] lines;
        string title;
        StringBuilder sb;

        dict = new Dictionary<string, string>();
        textAsset = Resources.Load(fileName) as TextAsset;
        lines = textAsset.text.Split('\n');
        title = "";
        sb = new StringBuilder();

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

    public List<string> ReturnHeader(string fileName)
    {
        TextAsset textAsset;
        string[] lines;
        List<string> header;

        textAsset = Resources.Load(fileName) as TextAsset;
        lines = textAsset.text.Split('\n');
        header = lines[0].Split(',').ToList();

        return header;
    }
}
