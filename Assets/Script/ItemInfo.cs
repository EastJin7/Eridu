using UnityEngine;
using System.Collections;

public static class ItemInfo{
    public static int[] itemId = new int[40];
    public static int[] itemType = new int[40];
    public static string[] itemName = new string[40];
    public static string[] itemContent = new string[40];
    public static int[] itemPrice = new int[40];
    public static int[] itemOwn = new int[40];
    static int i;

    static ItemInfo()
    {
        Debug.Log("Got info of item");
        for (i = 0; i < itemId.Length; i++)
        {
            itemId[i] = i;
            if (i <= 40) { itemType[i] = 3; }//other
            if (i < 35) { itemType[i] = 2; }//frindPoint
            if (i < 25) { itemType[i] = 1; }//crystal
            if (i < 15) { itemType[i] = 0; }//coins

        }
        itemName[0] = "治療藥水";
        itemContent[0] = "補充 20 HP";
        itemPrice[0] = 20;
        itemName[1] = "無敵藥水";
        itemContent[1] = "2 秒內獲得無敵狀態";
        itemPrice[1] = 40;
        itemName[2] = "防禦藥水";
        itemContent[2] = "10 秒內提高防禦力";
        itemPrice[2] = 30;

        itemName[24] = "鑰匙";
        itemContent[24] = "不知有何作用的鑰匙";
        itemPrice[24] = 100;



    }
    public static void CallItem()
    { }

    public static int Own(int id)
    {
        return itemOwn[id];
    }
}
