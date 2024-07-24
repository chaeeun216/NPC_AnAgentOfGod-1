using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Header("���ĵ� �Ϸ���Ʈ")]
    public Transform tf_standing;

    [Tooltip("ĳ����")]
    public string name; // ĳ���� �̸�

    [HideInInspector]	// �ν����� â���� ������ �����.
    public string[] contexts; // �迭�̶� ���� ��縦 ���� �� �ִ�.

    [HideInInspector]
    public string[] spriteName; // ���� ���� ��������Ʈ �̹���

    //[Header("ī�޶� Ÿ���� ���")]
    //public Transform tf_target;

    //[HideInInspector]
    //public string[] cutsceneName;   // ���� ���� �ƽ� �̹���
}

[System.Serializable]
public class DialogueEvent
{
    public string name;     // ��ȭ �̺�Ʈ �̸�

    public Vector2 line;    // x�ٺ��� y�ٱ����� ��縦 ������.
    public Dialogue[] dialogues;    // ��縦 ���� ���̼� �ϱ� ������ �迭 ����
}