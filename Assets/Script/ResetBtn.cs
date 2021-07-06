using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ResetBtn : MonoBehaviour , IPointerClickHandler
{

	// Use this for initialization
	void Start () {
        Button reset = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        //點擊事件
        GameState.playerName = null;
        PlayerPrefs.SetString("PlayerName", GameState.playerName);
        //財產
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("FriendPoints", 0);
        PlayerPrefs.SetInt("Crystal", 0);
        //關卡進度
        PlayerPrefs.SetInt("Process", 0);
        PlayerPrefs.SetInt("PowerLine", 0);
        PlayerPrefs.SetInt("HasKey", 0);
        PlayerPrefs.SetInt("Step1_4_1", 0);
        //技能
        PlayerPrefs.SetInt("ClearLv", 0);
        PlayerPrefs.SetInt("Skill_1_Lv", 0);
        PlayerPrefs.SetInt("Skill_2_Lv", 0);
        //遊戲統計資訊
        PlayerPrefs.SetInt("LoginTimes", 0);
        PlayerPrefs.SetFloat("AllGameTime", 0);
        PlayerPrefs.SetInt("Dead", 0);
        PlayerPrefs.SetInt("Kill", 0);
        PlayerPrefs.SetInt("NoKill", 0);
        PlayerPrefs.SetInt("Clear", 0);
        PlayerPrefs.SetInt("Sword", 0);
        PlayerPrefs.SetInt("SlimeKill", 0);
        PlayerPrefs.SetInt("WolfKill", 0);
        PlayerPrefs.SetInt("BatKill", 0);
        //通關次數
        PlayerPrefs.SetInt("PassStep1_1", 0);
        PlayerPrefs.SetInt("PassStep1_2", 0);
        int i;
        string j;
        for (i = 0; i < 200; i++)
        {
            j = i + "";
            PlayerPrefs.SetInt(("AchiRece" + j), 0);
            PlayerPrefs.SetInt(("AchiBoun" + j), 0);
        }
        for (i = 0; i < 40; i++)
        {
            j = i + "";
            PlayerPrefs.SetInt(("ItemOwn" + j), 0);
        }
        PlayerPrefs.SetInt(("ItemUse"), 0);
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
