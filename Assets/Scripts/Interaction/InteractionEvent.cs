using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue;

    // DatabaseManager에 저장된 실제 대사 데이터를 꺼내온다.
    public Dialogue[] GetDialogue()
    {
        DialogueEvent t_dialogueEvent = new DialogueEvent();    // 임시 변수
        t_dialogueEvent.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);

        for (int i = 0; i < dialogue.dialogues.Length; i++)
        {
            // dialogueEvent에 넣은 Standing Image 오브젝트를 임시 변수에 넣기
            t_dialogueEvent.dialogues[i].tf_standing = dialogue.dialogues[i].tf_standing;
        }

        // 원본에 임시 변수 덮어쓰기
        dialogue.dialogues = t_dialogueEvent.dialogues;

        return dialogue.dialogues;
    }
}