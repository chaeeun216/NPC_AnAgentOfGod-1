using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject LoadMenu;
    public GameObject ExitMenu;
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void OnClickMain()
    {
        Debug.Log("����");
        mainMenu.SetActive(true);
        LoadMenu.SetActive(false);
        optionMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    public void OnClickLoad()
    {
        Debug.Log("�ҷ�����");
        LoadMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    public void OnClickOption()
    {
        Debug.Log("����");
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        LoadMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    public void OnClickExit()
    {
        Debug.Log("���� ����");
        ExitMenu.SetActive(true);
        mainMenu.SetActive(false);
        LoadMenu.SetActive(false);
        optionMenu.SetActive(false);
    }

}