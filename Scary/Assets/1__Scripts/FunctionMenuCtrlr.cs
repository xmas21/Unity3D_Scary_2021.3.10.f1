﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FunctionMenuCtrlr : MonoBehaviour
{
    [SerializeField] [Header("進入遊戲 按鈕")] Button Btn_EnterGame;
    [SerializeField] [Header("進入遊戲 文字")] Text text_EnterGame;
    [SerializeField] [Header("遊戲設定 按鈕")] Button Btn_GameSetting;
    [SerializeField] [Header("製作人員 按鈕")] Button Btn_Team;
    [SerializeField] [Header("離開按鈕")] Button Btn_EndGame;

    [SerializeField] [Header("子物件 - Title")] GameObject Child_Title;
    [SerializeField] [Header("子物件 - Background")] GameObject Child_Background;
    [SerializeField] [Header("子物件 - EnterGame")] GameObject Child_EnterGame;
    [SerializeField] [Header("子物件 - Setting")] GameObject Child_Setting;
    [SerializeField] [Header("子物件 - Team")] GameObject Child_Team;
    [SerializeField] [Header("子物件 - EndGame")] GameObject Child_EndGame;

    GameManager gm;
    Scene currentScene;
    bool bInGame;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        bInGame = currentScene.name == "2 Grandma House";

        if (bInGame)
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        text_EnterGame.text = bInGame ? "繼續遊戲" : "返回遊戲";

        Btn_EnterGame.onClick.AddListener(() => StartResumeGame());
        Btn_GameSetting.onClick.AddListener(() => ShowGameSetting());
        Btn_Team.onClick.AddListener(() => ShowTeam());
        Btn_EndGame.onClick.AddListener(() => EndGame());
    }

    void StartResumeGame()
    {
        if (bInGame)
        {
            gm.SetGameState();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void ShowGameSetting()
    {
        HideAllBtn();
        GameObject SettingView = Btn_GameSetting.gameObject.transform.parent.GetChild(1).gameObject;
        SettingView.SetActive(true);
    }

    void ShowTeam()
    {
        HideAllBtn();
        GameObject TeamView = Btn_Team.gameObject.transform.parent.GetChild(1).gameObject;
        TeamView.SetActive(true);
    }

    void EndGame()
    {
        Application.Quit();
    }

    public void ShowAllBtn()
    {
        Btn_EnterGame.gameObject.SetActive(true);
        Btn_GameSetting.gameObject.SetActive(true);
        Btn_Team.gameObject.SetActive(true);
        Btn_EndGame.gameObject.SetActive(true);
    }

    void HideAllBtn()
    {
        Btn_EnterGame.gameObject.SetActive(false);
        Btn_GameSetting.gameObject.SetActive(false);
        Btn_Team.gameObject.SetActive(false);
        Btn_EndGame.gameObject.SetActive(false);
    }

    void HideAllChild()
    {
        Child_Title.SetActive(false);
        Child_Background.SetActive(false);
        Child_EnterGame.SetActive(false);
        Child_Setting.SetActive(false);
        Child_Team.SetActive(false);
        Child_EndGame.SetActive(false);
    }
}