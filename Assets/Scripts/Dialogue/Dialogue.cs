using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Header("스탠딩 일러스트")]
    public Transform tf_standing;

    [Tooltip("캐릭터")]
    public string name; // 캐릭터 이름

    [HideInInspector]	// 인스펙터 창에서 변수를 숨긴다.
    public string[] contexts; // 배열이라 여러 대사를 담을 수 있다.

    [HideInInspector]
    public string[] spriteName; // 여러 개의 스프라이트 이미지

    //[Header("카메라 타게팅 대상")]
    //public Transform tf_target;

    //[HideInInspector]
    //public string[] cutsceneName;   // 여러 개의 컷신 이미지
}

[System.Serializable]
public class DialogueEvent
{
    public string name;     // 대화 이벤트 이름

    public Vector2 line;    // x줄부터 y줄까지의 대사를 가져옴.
    public Dialogue[] dialogues;    // 대사를 여러 명이서 하기 때문에 배열 생성
}