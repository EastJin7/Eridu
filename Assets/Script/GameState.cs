using UnityEngine;
using System.Collections;

static class GameState
{//在點擊登入畫面進入遊戲時就會進行讀取。
 //於GameOver或Victory為true的情況下才會進行數據儲存。中途離開也會視為GameOver。

    //玩家資訊
    public static string playerName = null;
    public static float seVolume = 1;
    public static float BGMVolume = 1;
        //角色資訊
    public static int Id = 1;//目前選擇對象
    public static int giselleLv = 1;//吉榭爾等級
    public static int atlantLv = 1;//亞特蘭等級
    public static float gisellExp = 0;//吉榭爾經驗值
    public static float atlantExp = 0;//亞特蘭經驗值
//關卡狀態
    public static bool gameover = false;//遊戲是否失敗，死亡判斷。gameover時也會執行儲存部分數據的程式。
    public static bool gamepause = false;//遊戲是否暫停，劇情判斷、暫停選單
    public static bool victory = false;//遊戲是否勝利，進行結算和獲得金錢、劇情選項的數據傳輸
//角色金錢
    public static int allCoins = 0;//總金幣
    public static int friendP = 0;//友誼點數
    public static int crystal = 0;//商城幣
//關卡控制
    public static bool startstory = true;//開場劇情
    public static int process = 1;//關卡進度
    public static bool drama = true;//是否觸發這整個關卡的劇情
    public static bool powerline = false;//是否為恩利爾路線，是則不可進入恩基線
    public static bool key = false;//是否為持有鑰匙狀態，有會出現於道具欄，才可解鎖
//關卡是否解鎖
    public static bool step141 = false;
    public static bool step151 = false;
    //物品欄
    public static int itemUse = 0;
//技能欄
    public static int clearLv = 0;//淨化等級，0為為習得
    public static int skill1Lv = 0;//技能1等級，0為未習得
    public static int skill2Lv = 0;//技能2等級
//成就
    public static int loginTime = 0; //總登入次數
    public static float allGameTime = 0;//總遊戲時間
    public static int allDead = 0;//總死亡數
    public static int allKillA = 0;//總擊殺數
    public static int allNoKillA = 0;//總放生數
    public static int allClearA = 0;//總淨化數
    public static int allSword = 0;//總揮劍數
    public static int allTryCle = 0;//總嘗試淨化數
    public static int slimeKill = 0;
    public static int batKill = 0;
    public static int wolfKill = 0;
    public static int shopBuyTime = 0;//在商店購物的總次數
    public static int shopCostCry = 0;//在商店花費的水晶
    public static int passtime0101 = 0;//1-1通關次數
    public static int passtime0102 = 0;//1-2通關次數
    public static int passtime0103 = 0;//1-3通關次數
    public static int passtime010401 = 0;//1-4-1通關次數
//單場分數計算
    public static int dead = 0;//死亡數
    public static float gametime = 0;//遊戲時間
    public static int coins = 0;//獲得金幣
    public static int killa = 0;//該場擊殺數
    public static int noKilla = 0;//該場放生數，從該場怪物-擊殺數-淨化數獲得
    public static int cleara = 0;//該場淨化數
    public static int sword = 0;//該場揮劍數
    public static int tryCle = 0;//嘗試淨化數
}
