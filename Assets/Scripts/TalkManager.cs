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

        // scene 6, ���� �����
        // Door:101, Locker:102, Diary1:103, Diary2:104, Bible: 105, CCTV:106, Window:107, Wardrobe:108
        talkData.Add(101, new string[] { "���� ����ִ�.:0" });
        talkData.Add(103, new string[] { "�ϳ���, ���� �����Դϴ�.", "���� �뼭���ּ���.", "�׸��� �� �˸� ��� �Ͽ� ���ư��� �����Բ� �ʹ� ��������.", "���� �������� ���ڰ��� �� ���� �����ð� �ٽ� ��Ƴ��� ���� �Ͼ��.", "�׷��� ������ �������� ���ؼ� ��� �;��.", "�� ������ ���ż� ������ �Ǿ��ּ���.", "���� �׸������� �̸����� �⵵�帳�ϴ�.\n�Ƹ�." });
        talkData.Add(104, new string[] { "������ ���Ͻô� �ƹ����� ���Ͽ� �⵵�մϴ�.", "�� ���� ���� �����ϰ� �Ͻð�, �ð��� ����� �翪 �� ������ �� �ֵ��� ���� �Ǽ��� �ɷ��� ���Ͽ� �ֽÿɼҼ�.", "���� �����Ǵ� ������ ���Ͽ� �������� ��ȥ�� ��Ƴ��� ���� ���簡 �Ͼ�� �Ͻð�,\n������ �޴� �츮���� �Ƹ����� ȭ���Ͽ� �Ƹ��ٿ� ��ȸ�� ���� ������ �Ͽ� �ֽÿɼҼ�.", "�� ���踦 �ƹ������� �ε��Ͻð�, �츮�� ����ϻ� ���ڰ����� �� �긮�� �츮 �� ���� �׸������� �̸����� �⵵�帳�ϴ�.\n�Ƹ�." });
        talkData.Add(106, new string[] { "���� �� ���Ѻ��� �ִ� �ɱ�? ����Ģ�ء�:�Ҿ�" });//�ʻ�ȭ
        talkData.Add(105, new string[] { "�� ����� �� ������� ���� ���� �� ����� ���� ��ġ�� �� ū ���� �� �� �ֱ� �����̴�. \n- ������ <color=#A0522D>4</color>:<color=#FF0000>9</color>", "������ ������ �� ����� ���� �ִ�. �׵��� �ϳ����� �Ƶ��̶�� �Ҹ� ���̴�. \n- ���º��� <color=#FFD700>5</color>:<color=#008000>8</color>", "������ ���� ��� ���� �Ƿν� ���������� �� �긲�� ������ ���� �뼭�� ����. \n- ���긮�� <color=#>9</color>:<color=#0000FF>2</color>", "��... ���ڿ� ����� ǥ���� �� ������ ������...?:po" });
        talkData.Add(107, new string[] { "�� ����...\n�� ���� ���̸� â���� �ư� �پ���� ����� �� ����.:po", "�ֺ��� �� ���� �� ���̴� �� ���� Ȯ���� �б� ��ó�� �ƴ� �� ����...:po", "������ �� ���� �� ó�� �ﷷ�ŷ��� �� �Ǵ��� �´� ���� �𸣰ڳ�.:po" });

        // scene 7, ���� 2�� ����
        // 

        // scene 8, �⵵��
        // 


        // Quest Talk
        // Quest id + objId

        // Quest id=10 scene 6
        // Quest id + objId + talkIndex
        talkData.Add(10 + 102, new string[] { "�� ���ǽ��� ������ �ɷ��ִ�.", "� ���̰� ���� �� ���� ���� ������ ������.:po" });
        // ������ �����ؾ� ��
        talkData.Add(10 + 108, new string[] { "�̺��� ����ִ�.", "...:po", "�̺��� ��� ��������?\n�����ϱ� ����������...:po" });
        

        // Quest id=20 Scene 7
        // ��ġ ���� �� ���� �����ؾ���
        talkData.Add(20 + 1000, new string[] { "��𼱰� ���Ҹ��� ���.\n��ó�� Ż���� ������� ���ִ� �ɱ�?:portrait", "�������� �������� �����̾�θ� ���� ������ �� ���� ���� �ž�.:po", "�Ҹ��� �鸮�� ������ �����߰ھ�.:po" });

        //�������� �̵� �� �� ���� �ϴ� ����

        // Quest id=30 Scene 8
        // �⵵�� �̵�
        
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
                // �ش� ����Ʈ ���� �� ��簡 ���� ��
                // ����Ʈ �� ó�� ��縦 ������ �´�
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                // ����Ʈ �� ó�� ��縶�� ���� ��
                // �⺻ ��縦 ������ �´�
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
