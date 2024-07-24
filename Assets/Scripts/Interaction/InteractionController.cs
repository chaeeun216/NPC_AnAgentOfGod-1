using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    bool isInteractive = false; // 상호작용 가능 오브젝트에 접촉하는 최초의 순간에 true로 변경
    bool ZClickedInteractive = false; // 상호작용 가능 오브젝트를 클릭했는지

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

    public void CheckObject() // z 클릭으로 바꿔야 함
    {
        Debug.DrawRay(thePlayerAction.rigid.position, thePlayerAction.dirVec * 1.2f, new Color(0, 1, 0));
        hit = Physics2D.Raycast(thePlayerAction.rigid.position, thePlayerAction.dirVec, 1.2f, LayerMask.GetMask("EventObj"));
        
        if (hit.collider != null) // 사물을 스캔함
        {
            scanObj = hit.collider.gameObject;
            Contact();
        }
        else // 스캔된 사물이 없음
        {
            scanObj = null;
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

    public void ZClick() // z키로 상호작용 했을 때 Interact 함수 호출
    {
        // 이벤트 동안, 다른 상호작용 막기
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

    void Interact() // 상호작용한 오브젝트의 대사 이벤트를 꺼내옴
    {
        ZClickedInteractive = true;
        theDialogueManager.ShowDialogue(hit.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
