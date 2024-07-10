using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    bool isInteractive = false;

    public GameObject hit;

    DialogueManager theDialogueManager;
    PlayerAction thePlayerAction;

    void Start()
    {
        theDialogueManager = FindObjectOfType<DialogueManager>();
        thePlayerAction = FindObjectOfType<PlayerAction>();
    }

    public void CheckObject(GameObject scanObj) // z Ŭ������ �ٲ�� ��
    {
        hit = scanObj;
        if (hit != null)
        {
            Contact();
        }
        else
        {
            NotContact();
        }
    }

    void Contact() // ��ü�� ��ĵ���� �� ����
    {
        if (!isInteractive)
        {
            isInteractive = true;
        }
    }

    void NotContact()
    {
        isInteractive = false;
    }

    public void ZClick()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (isInteractive)
            {
                Interact();
            }
        }
    }

    void Interact()
    {
        hit = thePlayerAction.scanObj;
        theDialogueManager.ShowDialogue(hit.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
