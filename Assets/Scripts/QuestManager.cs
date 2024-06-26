using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("여자 기숙사에서 탈출하기.", new int[] { 1000, 100, 101, 102, 103, 104, 105 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        // Next Talk Target
        if (id == questList[questId].objId[questActionIndex])
            questActionIndex++;

        // Control Quest Object
        ControlObject();

        // Talk Complete & Nex Quest
        if (questActionIndex == questList[questId].objId.Length)
            NextQuest();

        // Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        // Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
