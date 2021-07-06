using UnityEngine;
using System.Collections;

public static class AchieveInfo
{
    public static int[] achiId = new int[200];//成就編號
    public static string[] achiName = new string[200];//成就名稱
    public static string[] achiContent = new string[200];//成就內容
    public static bool[] achiBoun = new bool[200];//是否已達成和彈跳視窗
    public static bool[] achiRece = new bool[200];//是否已領取
    public static int[] achiward = new int[200];//獎勵水晶數
    static int i;

    static AchieveInfo()
    {
        Debug.Log("成就建構子呼喚完成");
        for (i = 0; i < achiId.Length; i++)
        {
            achiId[i] = i;
        }
        achiName[0] = "師傅的懲罰";
        achiContent[0] = "普通攻擊 100 次";
        achiward[0] = 1;

        achiName[5] = "帶著光芒的";
        achiContent[5] = "使用淨化 100 次";
        achiward[5] = 1;

        achiName[10] = "偷懶成性";
        achiContent[10] = "忽略怪物 20 次";
        achiward[10] = 1;

        achiName[20] = "復仇之火";
        achiContent[20] = "擊殺魔物 20 次";
        achiward[20] = 2;

        achiName[30] = "就是那道光！";
        achiContent[30] = "淨化魔物 20 次";
        achiward[30] = 2;

        achiName[40] = "我才不理你！";
        achiContent[40] = "拒絕史萊姆的請求";
        achiward[40] = 5;
        achiName[41] = "熱心公「液」";
        achiContent[41] = "答應史萊姆的請求";
        achiward[41] = 5;
        achiName[42] = "遇見神秘人";
        achiContent[42] = "那傢伙到底是誰啊？";
        achiward[42] = 3;
        achiName[43] = "烏爾的利刃";
        achiContent[43] = "解鎖亞特蘭";
        achiward[43] = 10;
        achiName[44] = "密不能當飯吃！";
        achiContent[44] = "解鎖艾德蒙";
        achiward[44] = 10;
        achiName[45] = "人與神";
        achiContent[45] = "完成最終章序曲";
        achiward[45] = 20;
        achiName[46] = "吉榭爾";
        achiContent[46] = "完成吉榭爾篇最終章 (1)";
        achiward[46] = 25;
        achiName[47] = "邪惡的根源";
        achiContent[47] = "完成吉榭爾篇最終章 (2)";
        achiward[47] = 25;

        achiName[60] = "你喜歡寶石嗎？";
        achiContent[60] = "累計登入 20 次";
        achiward[60] = 5;

        achiName[65] = "徘徊的人";
        achiContent[65] = "累計遊戲時間達到 1 小時";
        achiward[65] = 5;

        achiName[70] = "堅持不懈！";
        achiContent[70] = "死亡次數達到 20 次";
        achiward[70] = 1;

        achiName[80] = "勤儉持家";
        achiContent[80] = "持有金幣持有量超過 500";
        achiward[80] = 3;

        achiName[85] = "友達萬歲！";
        achiContent[85] = "友誼點數持有量超過 100";
        achiward[85] = 5;

        achiName[90] = "毅力過人";
        achiContent[90] = "水晶持有量超過 50";
        achiward[90] = 5;

        achiName[95] = "銘謝惠顧";
        achiContent[95] = "在商店購物超過 10 次";
        achiward[95] = 3;

        achiName[98] = "花錢如水";
        achiContent[98] = "在商店消耗的水晶量超過 100";

        achiName[100] = "藥水戰術";
        achiContent[100] = "在戰鬥中使用藥水 20 次";
        achiward[100] = 3;

        achiName[105] = "身心強健";
        achiContent[105] = "提升被動技能等級 10 次";
        achiward[105] = 5;
        achiName[109] = "健身大師";
        achiContent[109] = "提升被動技能等級 100 次";
        achiward[109] = 30;

        achiName[110] = "只是液體而已？！";
        achiContent[110] = "擊殺 10 隻史萊姆";
        achiward[110] = 1;
        achiName[111] = "抽刀斷水";
        achiContent[111] = "擊殺 30 隻史萊姆";
        achiward[111] = 5;

        achiName[115] = "是怎麼看見我的？";
        achiContent[115] = "擊殺 10 隻蝙蝠";
        achiward[115] = 3;
        achiName[116] = "閉著眼睛也能攻擊";
        achiContent[116] = "擊殺 30 隻蝙蝠";
        achiward[116] = 8;

        achiName[120] = "黑影襲來";
        achiContent[120] = "擊殺 10 隻狼";
        achiward[120] = 6;
        achiName[121] = "嗜血的";
        achiContent[121] = "擊殺 30 隻狼";
        achiward[121] = 12;

        achiName[160] = "異變的開始";
        achiContent[160] = "完成第一章 1 次";
        achiward[160] = 2;
        achiName[161] = "拯救烏努格";
        achiContent[161] = "完成第一章 10 次";
        achiward[161] = 5;

        achiName[190] = "小心地上！";
        achiContent[190] = "摔落地板 30 次";
        achiward[190] = 1;
    }

    public static void FirstStart()
    {
       
    }
}
