using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);    // CSV 데이터

        if (csvData == null)
        {
            Debug.LogError("CSV file not found: " + _CSVFileName);
            return null;
        }

        string[] data = csvData.text.Split(new char[] { '\n' });    // 엔터 단위로 대사 쪼개기

        for (int i = 1; i < data.Length;)   // data[0] = {'ID', '캐릭터 이름', '대사'}
        {
            string[] row = data[i].Split(new char[] { ',' });   // , 단위로 쪼개기

            Dialogue dialogue = new Dialogue(); // 캐릭터 한 명의 대사들

            dialogue.name = row[1];
            Debug.Log(row[1]); // 디버깅
            List<string> contextList = new List<string>();
            List<string> spriteList = new List<string>(); // 사진리스트
            //List<string> cutsceneList = new List<string>(); // 컷신 이미지 리스트

            do
            { 
                contextList.Add(row[2]);
                Debug.Log(row[2]); // 디버깅
                spriteList.Add(row[3]); // 엑셀 3번째 내용

                // 다음 줄 미리 비교
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                // 다음 줄이 데이터 보다 길어지면 그냥 break
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");  // 다음 줄 캐릭터 이름이 공백이면 대사를 더 채우기

            dialogue.contexts = contextList.ToArray();   // 리스트를 배열로
            dialogue.spriteName = spriteList.ToArray();
            //dialogue.cutsceneName = cutsceneList.ToArray();
            dialogueList.Add(dialogue); // 한캐릭터가 다른 캐릭터가 말하기 전까지 모든 대사들이 묶여서 추가됨
        }

        return dialogueList.ToArray();
    }
}
