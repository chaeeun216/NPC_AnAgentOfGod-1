using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]	// ĳ���� �̸��� inspector â�� ���
    public string name; // ĳ���� �̸�

    [Tooltip("��� ����")]
    public string[] context; // �迭�̶� ���� ��縦 ���� �� ����.
}

[System.Serializable]
public class DialogueEvent
{
    public string name;     // ��ȭ �̺�Ʈ �̸�
    public Vector2 line;    // x�ٺ��� y�ٱ����� ��縦 ������.
    public Dialogue[] dialogues;    // ��縦 ���� ���̼� �ϱ� ������ �迭 ����
}