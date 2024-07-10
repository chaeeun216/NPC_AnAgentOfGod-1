using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text 클래스
using TMPro; // TMP TEXT 클래스

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_NameBar;
    [SerializeField] GameObject go_standingImage;

    [SerializeField] TMP_Text txt_Dialogue;
    [SerializeField] TMP_Text txt_Name;

    bool isDialogue = false;    // 현재 대화중인지
    bool isNext = false; // 특정 키 입력 대기

    Dialogue[] dialogues;

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int lineCount = 0; // 대화 카운트 == ID
    int contextCount = 0; // 대사 카운트

    SpriteManager theSpriteManager;
    InteractionController ic;

    void Start()
    {
        ic = FindObjectOfType<InteractionController>();
        theSpriteManager = FindFirstObjectByType<SpriteManager>();
    }

    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    txt_Dialogue.text = "";

                    // 현재 캐릭터의 다음 대사 출력
                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }

                    // 다음 캐릭터의 대사 출력
                    else
                    {
                        contextCount = 0;

                        if (++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        // 다음 캐릭터가 없으면 (대화가 끝났으면)
                        else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    void ChangeSprite()
    {
        // 캐릭터가 대사를 할 때, spriteName이 공백이 아니면 이미지 변경
        StartCoroutine(theSpriteManager.SpriteChangeCoroutine(dialogues[lineCount].tf_target, dialogues[lineCount].spriteName[contextCount]));
    }

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        txt_Dialogue.text = "";
        txt_Name.text = "";

        isDialogue = true;
        dialogues = p_dialogues;

        SettingUI(true);    // 대사창, 이름창 보이기
    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUI(false);
    }

    // 텍스트 출력 코루틴
    IEnumerator TypeWriter()
    {
        SettingUI(true);    // 대사창 이미지를 띄운다.
        ChangeSprite();		// 스탠딩 이미지를 변경한다.

        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];   // 특수문자를 ,로 치환
        t_ReplaceText = t_ReplaceText.Replace("`", ",");    // backtick을 comma로 변환

        txt_Dialogue.text = dialogues[lineCount].name;

        isNext = true;
        yield return null;   // 다음 대사를 출력 가능하도록
    }

    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_NameBar.SetActive(p_flag);
        go_standingImage.SetActive(p_flag);
    }
}
