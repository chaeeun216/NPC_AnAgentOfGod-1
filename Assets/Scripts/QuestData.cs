using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
    public int[] objId;

    public QuestData(string name, int[] code)
    {
        questName = name;
        objId = code;
    }
}
