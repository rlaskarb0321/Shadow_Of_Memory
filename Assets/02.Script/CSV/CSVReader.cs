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

        // 타이틀 값 다음 줄부터 내용물을 맞는 타이틀끼리 분리시키기
        for (int i = 1; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(',');

            // 타이틀값이 있다
            if (!line[0].Equals(""))
            {
                // 전에 title값이 존재하면
                if (!title.Equals(""))
                {
                    // sb에 쌓아둔 값들을 "전 title값 == 딕셔너리 키" 인 곳 value에 추가
                    string context = sb.ToString();
                    dict[title] = context;
                }

                // 새 타이틀값 적용
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
