using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] float fadeSpeed; // �̹����� ������ �ڿ������� ����

    bool CheckSameSprite(Image p_image, Sprite p_sprite) // ��������Ʈ�� ������
    {
        if (p_image.sprite == p_sprite)
            return true;
        else
            return false;
    }

    // p_target: � �̹����� ������ ������, p_spriteName: � �̹����� ������ ������
    public IEnumerator SpriteChangeCoroutine(Transform p_target, string p_spriteName)
    {
        // 1. t_image �̹����� ����
        // Standing Image ������Ʈ���� Image ������Ʈ X �� �� �ڽ��� Image ������Ʈ���� Image ������Ʈ O
        Image t_image = p_target.GetComponentInChildren<Image>();

        // 2. t_sprite �̹����� ����
        // Characters ������ �ִ� �̹����� ������ Sprite Ÿ������ ���� �������� ������ ��, Sprite�� ���� ����ȯ
        p_spriteName = p_spriteName.Trim(); // ���� ����
        Sprite t_sprite = Resources.Load("Characters/" + p_spriteName, typeof(Sprite)) as Sprite;

        // �� �̹����� ���� ������ �� �̹����� ����
        if (!CheckSameSprite(t_image, t_sprite))
        {
            // 1. ���� �̹����� �����
            Color t_color = t_image.color; // ���� �̹����� color �Ӽ�
            t_color.a = 0;  // ������ 0����
            t_image.color = t_color;       // �ٲ� ������ ����

            // 2. �� �̹����� �����ֱ�
            t_image.sprite = t_sprite;     // �̹��� ��ü

            while (t_color.a < 1)
            {
                if (t_sprite != null)
                {
                    t_color.a += fadeSpeed; // ������ 0�������� ������ �ø���
                    t_image.color = t_color;   // �ٲ� ������ ����
                }

                yield return null;  // 1������ ���
            }
        }
    }
}
