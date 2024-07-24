using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text Ŭ����
using TMPro; // TMP TEXT Ŭ����

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_NameBar;
    [SerializeField] GameObject go_standingImage;

    [SerializeField] TMP_Text txt_Dialogue;
    [SerializeField] TMP_Text txt_Name;

    bool isDialogue = false;    // ���� ��ȭ������
    bool isNext = false; // Ư�� Ű �Է� ���

    Dialogue[] dialogues;

    [Header("�ؽ�Ʈ ��� ������")]
    [SerializeField] float textDelay;

    int lineCount = 0; // ��ȭ ī��Ʈ == ID
    int contextCount = 0; // ��� ī��Ʈ

    SpriteManager theSpriteManager;
    CutsceneManager theCutsceneManager;
    InteractionController ic;

    void Start()
    {
        ic = FindObjectOfType<InteractionController>();
        theSpriteManager = FindFirstObjectByType<SpriteManager>();
        theCutsceneManager = FindObjectOfType<CutsceneManager>();
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

                    // ���� ĳ������ ���� ��� ���
                    // ���� ĳ������ ��簡 ���� �ִٸ�, �װ� ��� ���
                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }

                    // ���� ĳ������ ��� ���
                    else
                    {
                        contextCount = 0; // ��� ��

                        if (++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        // ���� ĳ���Ͱ� ������ (��ȭ�� ��������)
                        else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    //void ChangeSprite()
    //{
    //    // ĳ���Ͱ� ��縦 �� ��, spriteName�� ������ �ƴϸ� �̹��� ����
    //    StartCoroutine(theSpriteManager.SpriteChangeCoroutine(dialogues[lineCount].tf_target, dialogues[lineCount].spriteName[contextCount]));
    //}

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        txt_Dialogue.text = "";
        txt_Name.text = "";

        isDialogue = true; // ���� ��ȭ ����
        SettingUI(true);    // ���â, �̸�â ���̱�
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter()); // ��ȣ�ۿ� ���ÿ� �ؽ�Ʈ ��� �ڷ�ƾ ����
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

    // �ؽ�Ʈ ��� �ڷ�ƾ
    IEnumerator TypeWriter()
    {
        SettingUI(true);    // ���â �̹����� ����.
       // ChangeSprite();		// ���ĵ� �̹����� �����Ѵ�.

        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];   // Ư�����ڸ� ,�� ġȯ
        t_ReplaceText = t_ReplaceText.Replace("`", ",");    // backtick�� comma�� ��ȯ

        txt_Name.text = dialogues[lineCount].name; // ���â�� ĳ���� �̸� ���

        // ���â�� ��� �� ���ھ� ���
        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }

        isNext = true; // ���� ��縦 ��� �����ϵ���
    }

    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_NameBar.SetActive(p_flag);
        // go_standingImage.SetActive(p_flag);
    }
}
