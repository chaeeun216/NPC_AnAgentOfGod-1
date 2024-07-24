using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue;

    // DatabaseManager�� ����� ���� ��� �����͸� �����´�.
    public Dialogue[] GetDialogue()
    {
        DialogueEvent t_dialogueEvent = new DialogueEvent();    // �ӽ� ����
        t_dialogueEvent.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);

        for (int i = 0; i < dialogue.dialogues.Length; i++)
        {
            // dialogueEvent�� ���� Standing Image ������Ʈ�� �ӽ� ������ �ֱ�
            t_dialogueEvent.dialogues[i].tf_standing = dialogue.dialogues[i].tf_standing;
        }

        // ������ �ӽ� ���� �����
        dialogue.dialogues = t_dialogueEvent.dialogues;

        return dialogue.dialogues;
    }
}