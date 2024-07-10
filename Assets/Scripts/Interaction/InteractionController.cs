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

    public void CheckObject(GameObject scanObj) // z 클릭으로 바꿔야 함
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

    void Contact() // 물체를 스캔했을 때 실행
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
