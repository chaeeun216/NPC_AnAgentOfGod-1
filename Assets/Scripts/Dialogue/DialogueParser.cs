using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    private void Start()
    {
        Parse("scene02");
    }

    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // ��� ����Ʈ
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);    // CSV ������

        string[] data = csvData.text.Split(new char[] { '\n' });    // ���� ������ ��� �ɰ���

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });   // , ������ �ɰ���

            Dialogue dialogue = new Dialogue(); // ĳ���� �� ���� ����

            dialogue.name = row[1];
            Debug.Log(row[1]);

            List<string> contextList = new List<string>();

            do
            {
                contextList.Add(row[2]);
                Debug.Log(row[2]);

                // ���� �� �̸� ��
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }

                // ���� ���� ������ ���� ������� �׳� break
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");  // ���� �� ĳ���� �̸��� �����̸� ��縦 �� ä���


            // dialogue.context = row[2] �� context�� �迭�̱� ������ �̷� ������ �Ҵ��� �� X.
            dialogue.context = contextList.ToArray();   // ����Ʈ�� �迭��
            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }
}
