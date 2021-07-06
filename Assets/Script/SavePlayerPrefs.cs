using UnityEngine;
using System.Collections;
using System;

public class SavePlayerPrefs : MonoBehaviour {
    //放在空物件上，用來儲存、讀取數據，並且在遊戲勝利時進行統計

    bool overTemp = false;
    int time = 0;

	void Awake () {
        if (GameState.playerName == null)
        {
            Load();//開啟場景且暱稱為空時就讀取
        }
    }

    public void GameOver()
    {
        if (GameState.gameover && !overTemp)
        {
            overTemp = true;
            Debug.Log("失敗");
            StartCoroutine(Total(false));
        }
    }

    public void VictoryTotal()
    {
        if (!overTemp)
        {
            overTemp = true;
            Debug.Log("勝利");
            StartCoroutine(Total(true));
        }
    }
    
    IEnumerator Total(bool v)//進行統計
    {
            GameState.gametime = Time.time;
            GameState.allGameTime += GameState.gametime;
            GameState.allDead += GameState.dead;
            if (v)
            {
                yield return new WaitForSeconds(0.5f);//結算等待中（等其他傳值完）
                RecordSaving();
            }
            Save();
            yield return new WaitForSeconds(1f);
            Reset();
    }
    void RecordSaving()
    {
        UIManager.Instance.ShowPanel("VictoryUI");//結算
        GameState.allNoKillA += GameState.noKilla;
        GameState.allCoins += GameState.coins;
        Debug.Log("結算完畢");
    }

    void Reset()//單場數值重置
    {
        GameState.coins = 0;
        GameState.dead = 0;
        GameState.cleara = 0;
        GameState.killa = 0;
        GameState.noKilla = 0;
        GameState.sword = 0;
        GameState.tryCle = 0;
        Debug.Log("重置完成");
    }

    int BoolToInt(bool b)//布林轉INT
    {
        if(b)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    bool IntToBool(int i)//整數轉布林
    {
        if(i==1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Save()
    {
        Debug.Log("儲存資料");
        GameState.victory = false;
        //儲存開始
        //玩家資訊
        PlayerPrefs.SetString("PlayerName", GameState.playerName);
        PlayerPrefs.SetFloat("BGMVolume", GameState.BGMVolume);
        PlayerPrefs.SetFloat("SeVolume", GameState.seVolume);
        //財產
        PlayerPrefs.SetInt("Coins", GameState.allCoins);
        PlayerPrefs.SetInt("FriendPoints", GameState.friendP);
        PlayerPrefs.SetInt("Crystal", GameState.crystal);
        //關卡進度
        PlayerPrefs.SetInt("Process", GameState.process);
        PlayerPrefs.SetInt("PowerLine", BoolToInt(GameState.powerline));
        PlayerPrefs.SetInt("HasKey", BoolToInt(GameState.key));
        PlayerPrefs.SetInt("Step1_4_1", BoolToInt(GameState.step141));
        //技能
        PlayerPrefs.SetInt("ClearLv", GameState.clearLv);
        PlayerPrefs.SetInt("Skill_1_Lv", GameState.skill1Lv);
        PlayerPrefs.SetInt("Skill_2_Lv", GameState.skill2Lv);
        //遊戲統計資訊
        PlayerPrefs.SetInt("LoginTimes", GameState.loginTime);
        PlayerPrefs.SetFloat("AllGameTime", GameState.allGameTime);
        PlayerPrefs.SetInt("Dead", GameState.allDead);
        PlayerPrefs.SetInt("Kill", GameState.allKillA);
        PlayerPrefs.SetInt("NoKill", GameState.allNoKillA);
        PlayerPrefs.SetInt("Clear", GameState.allClearA);
        PlayerPrefs.SetInt("Sword", GameState.allSword);
        PlayerPrefs.SetInt("SlimeKill", GameState.slimeKill);
        PlayerPrefs.SetInt("WolfKill", GameState.wolfKill);
        PlayerPrefs.SetInt("BatKill", GameState.batKill);
        //通關次數
        PlayerPrefs.SetInt("PassStep1_1", GameState.passtime0101);
        PlayerPrefs.SetInt("PassStep1_2", GameState.passtime0102);
        int i;
        string j;
        for (i = 0; i < 200; i++)
        {
            j = i + "";
            PlayerPrefs.SetInt(("AchiRece"+j), BoolToInt(AchieveInfo.achiRece[i]));
            PlayerPrefs.SetInt(("AchiBoun" + j), BoolToInt(AchieveInfo.achiBoun[i]));
        }
        for(i=0;i<40;i++)
        {
            j = i + "";
            PlayerPrefs.SetInt(("ItemOwn" + j), ItemInfo.itemOwn[i]);
        }
        PlayerPrefs.SetInt(("ItemUse"), GameState.itemUse);
    }

        public void Load()
    {
        Debug.Log("讀取資料\n");
        //玩家資訊
        GameState.playerName = PlayerPrefs.GetString("PlayerName");
        GameState.BGMVolume = PlayerPrefs.GetFloat("BGMVolume",1);
        GameState.seVolume = PlayerPrefs.GetFloat("SeVolume", 1);
        //財產
        GameState.allCoins = PlayerPrefs.GetInt("Coins", 0);
        GameState.friendP = PlayerPrefs.GetInt("FriendPoints", 0);
        GameState.crystal = PlayerPrefs.GetInt("Crystal");
//進度
        GameState.process = PlayerPrefs.GetInt("Process", 1);
        GameState.powerline = IntToBool(PlayerPrefs.GetInt("PowerLine", 0));
        GameState.key = IntToBool(PlayerPrefs.GetInt("HasKey", 0));
        GameState.step141 = IntToBool(PlayerPrefs.GetInt("Step1_4_1", 0));
        //技能
        GameState.clearLv = PlayerPrefs.GetInt("ClearLv", 0);
        GameState.skill1Lv = PlayerPrefs.GetInt("Skill_1_Lv", 0);
        GameState.skill2Lv = PlayerPrefs.GetInt("skill_2_lv", 0);
        //統計資訊
        GameState.loginTime = PlayerPrefs.GetInt("LoginTimes", 0);
        GameState.allGameTime = PlayerPrefs.GetInt("AllGameTime", 1);
        GameState.allDead = PlayerPrefs.GetInt("Dead", 0);
        GameState.allKillA = PlayerPrefs.GetInt("Kill", 0);
        GameState.allNoKillA = PlayerPrefs.GetInt("NoKill", 0);
        GameState.allClearA = PlayerPrefs.GetInt("Clear", 0);
        GameState.allSword = PlayerPrefs.GetInt("Sword", 0);
        GameState.slimeKill = PlayerPrefs.GetInt("SlimeKill", 0);
        GameState.wolfKill = PlayerPrefs.GetInt("WolfKill", 0);
        GameState.batKill = PlayerPrefs.GetInt("BatKill", 0);
        //通關次數
        GameState.passtime0101 = PlayerPrefs.GetInt("PassStep1_1", 0);
        GameState.passtime0102 = PlayerPrefs.GetInt("PassStep1_2", 0);
        int i;
        string j;
        for (i = 0; i < 200; i++)//成就
        {
            j = i + "";
            AchieveInfo.achiRece[i] = IntToBool(PlayerPrefs.GetInt(("AchiRece" + j), 0));
            AchieveInfo.achiBoun[i] = IntToBool(PlayerPrefs.GetInt(("AchiBoun" + j), 0));
        }
        for(i=0; i<40; i++)//物品
        {
            j = i + "";
            ItemInfo.itemOwn[i] = PlayerPrefs.GetInt(("ItemOwn"+j),0);
        }
        GameState.itemUse = PlayerPrefs.GetInt(("ItemUse"),0);
    }
}
    //PlayerPrefs.DeleteAll(): 
    //移除所有鍵和值
    //PlayerPrefs.DeleteKey(key)
    //移除key和它對應的值。

    //PlayerPrefs.GetFloat("key", defaultValue)
    //PlayerPrefs.GetInt("key", defaultValue)
    //PlayerPrefs.GetString("key")
    //如果存在，返回key對應的值.如果不存在，返回defaultValue
    //PlayerPrefs.HasKey(key)
    //如果存在key則返回真

    //PlayerPrefs.SetFloat("key", 10.0);;
    //PlayerPrefs.SetInt("key", 10);
    //PlayerPrefs.SetString("key","sting")
    //設置由key確定的值.
