using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // Talk Data
        // NPC Luna:1000, NPC Ludo:2000

        // scene 6, 여자 기숙사
        // Door:101, Locker:102, Diary1:103, Diary2:104, Bible: 105, CCTV:106, Window:107, Wardrobe:108
        talkData.Add(101, new string[] { "문이 잠겨있다.:0" });
        talkData.Add(103, new string[] { "하나님, 저는 죄인입니다.", "저를 용서해주세요.", "그리고 제 죄를 대신 하여 돌아가신 예수님께 너무 감사드려요.", "저는 예수님이 십자가에 못 박혀 죽으시고 다시 살아나신 것을 믿어요.", "그래서 이제는 예수님을 위해서 살고 싶어요.", "제 마음에 오셔서 주인이 되어주세요.", "예수 그리스도의 이름으로 기도드립니다.\n아멘." });
        talkData.Add(104, new string[] { "말씀을 전하시는 아버지를 위하여 기도합니다.", "늘 영육 간에 강건하게 하시고, 맡겨진 목양의 사역 잘 감당할 수 있도록 영적 권세와 능력을 더하여 주시옵소서.", "오늘 선포되는 말씀을 통하여 성도들의 영혼이 살아나는 귀한 역사가 일어나게 하시고,\n말씀을 받는 우리들은 아멘으로 화답하여 아름다운 교회를 세워 나가게 하여 주시옵소서.", "이 예배를 아버지께서 인도하시고, 우리를 사랑하사 십자가에서 피 흘리신 우리 주 예수 그리스도의 이름으로 기도드립니다.\n아멘." });
        talkData.Add(106, new string[] { "누가 날 지켜보고 있는 걸까? 꺼림칙해…:불안" });//초상화
        talkData.Add(105, new string[] { "두 사람이 한 사람보다 나은 것은 두 사람이 힘을 합치면 더 큰 일을 할 수 있기 때문이다. \n- 전도서 <color=#A0522D>4</color>:<color=#FF0000>9</color>", "마음을 깨끗이 한 사람은 복이 있다. 그들이 하나님의 아들이라고 불릴 것이다. \n- 마태복음 <color=#FFD700>5</color>:<color=#008000>8</color>", "율법은 거의 모든 것이 피로써 깨끗해지며 피 흘림이 없으면 죄의 용서도 없다. \n- 히브리서 <color=#>9</color>:<color=#0000FF>2</color>", "음... 숫자에 색깔로 표시해 둔 이유가 있을까...?:po" });
        talkData.Add(107, new string[] { "안 열려...\n이 정도 높이면 창문을 꺠고 뛰어내려도 즉사할 것 같아.:po", "주변에 산 같은 ㄱ 보이는 걸 보면 확실히 학교 근처는 아닌 것 같고...:po", "으으… 술 마신 것 처럼 울렁거려서 내 판단이 맞는 지도 모르겠네.:po" });

        // scene 7, 지하 2층 복도
        // 

        // scene 8, 기도실
        // 


        // Quest Talk
        // Quest id + objId

        // Quest id=10 scene 6
        // Quest id + objId + talkIndex
        talkData.Add(10 + 102, new string[] { "흰 원피스와 정장이 걸려있다.", "어린 아이가 입을 수 있을 만한 사이즈 같은데.:po" });
        // 선택지 구현해야 함
        talkData.Add(10 + 108, new string[] { "이불이 들어있다.", "...:po", "이불을 모두 꺼내볼까?\n정리하기 귀찮겠지만...:po" });
        

        // Quest id=20 Scene 7
        // 위치 도착 시 독백 구현해야함
        talkData.Add(20 + 1000, new string[] { "어디선가 말소리가 들려.\n나처럼 탈출한 사람들이 모여있는 걸까?:portrait", "누군가가 해코지할 작정이어싸면 내가 잠들었을 때 진작 했을 거야.:po", "소리가 들리는 쪽으로 가봐야겠어.:po" });

        //왼쪽으로 이동 시 못 가게 하는 독백

        // Quest id=30 Scene 8
        // 기도실 이동
        
        // Portrait Data
        //0:Normal, 1:Speak, 2:Happy, 3:Angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                // 해당 퀘스트 진행 중 대사가 없을 때
                // 퀘스트 맨 처음 대사를 가지고 온다
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                // 퀘스트 맨 처음 대사마저 없을 때
                // 기본 대사를 가지고 온다
                return GetTalk(id - id % 10, talkIndex);
            }

        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
