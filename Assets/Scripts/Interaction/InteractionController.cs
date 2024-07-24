using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    bool isInteractive = false; // ��ȣ�ۿ� ���� ������Ʈ�� �����ϴ� ������ ������ true�� ����
    bool ZClickedInteractive = false; // ��ȣ�ۿ� ���� ������Ʈ�� Ŭ���ߴ���

    RaycastHit2D hit;
    public GameObject scanObj;

    DialogueManager theDialogueManager;
    PlayerAction thePlayerAction;

    void Start()
    {
        theDialogueManager = FindObjectOfType<DialogueManager>();
        thePlayerAction = FindObjectOfType<PlayerAction>();
    }

    void Update()
    {
        if (!ZClickedInteractive)
        {
            CheckObject();
            ZClick();
        }
    }

    public void CheckObject() // z Ŭ������ �ٲ�� ��
    {
        Debug.DrawRay(thePlayerAction.rigid.position, thePlayerAction.dirVec * 1.2f, new Color(0, 1, 0));
        hit = Physics2D.Raycast(thePlayerAction.rigid.position, thePlayerAction.dirVec, 1.2f, LayerMask.GetMask("EventObj"));
        
        if (hit.collider != null) // �繰�� ��ĵ��
        {
            scanObj = hit.collider.gameObject;
            Contact();
        }
        else // ��ĵ�� �繰�� ����
        {
            scanObj = null;
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

    public void ZClick() // zŰ�� ��ȣ�ۿ� ���� �� Interact �Լ� ȣ��
    {
        // �̺�Ʈ ����, �ٸ� ��ȣ�ۿ� ����
        if (!ZClickedInteractive)
        {
            if (Input.GetKeyDown(KeyCode.Z) && scanObj != null)
            {
                if (isInteractive)
                {
                    Debug.Log(scanObj.name);
                    Interact();
                }
            }
        }
    }

    void Interact() // ��ȣ�ۿ��� ������Ʈ�� ��� �̺�Ʈ�� ������
    {
        ZClickedInteractive = true;
        theDialogueManager.ShowDialogue(hit.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
