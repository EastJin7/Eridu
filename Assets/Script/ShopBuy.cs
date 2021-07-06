using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using System.Linq;

public class ShopBuy : MonoBehaviour
{
    //一個腳本監聽兩個Button按下事件，並對Text產生變化
    public int type;//消耗貨幣類型 0為金幣 1為水晶 2為友點
    [SerializeField]
    private Text itemName;//顯示物品名稱
    [SerializeField]
    private Text itemContent;//顯示物品內容
    [SerializeField]
    public int itemId;//ID由編輯器指定，會被購買鍵存取
    [SerializeField]
    private Text buyAmount;//購買數量
    [SerializeField]
    private Button add;//增加鍵
    [SerializeField]
    private Button de;//減少鍵
    [SerializeField]
    private Text costText;//成本顯示的文字
    private int cost;//單件成本，初始時保存
    public int a; //數量
    private int totalCost;//該物品總成本
    [SerializeField]
    private Image back;//背景圖片
    [SerializeField]
    private Image iconBack;//圖標背景
    [SerializeField]
    private ShopManager shop;//獲取商店管理員來執行總成本計算

    void Awake()
    {
        //獲取該ID物品資訊
        type = ItemInfo.itemType[itemId];
        itemName.text = ItemInfo.itemName[itemId];
        itemContent.text = ItemInfo.itemContent[itemId];
        costText.text = ItemInfo.itemPrice[itemId] + "";
        if (ItemInfo.itemOwn[itemId] == 0)
        {
            iconBack.color = new Color32(90, 173, 255, 255);
        }
        else
        {
            iconBack.color = new Color32(32, 54, 77, 255);
        }
    }
    void Start()
    {
        //初始化
        buyAmount.text = "0";
        a = 0;
        cost = Int32.Parse(costText.text);
        back.color = new Color32(135,161,255,255);

        //註冊button1的trigger
        EventTrigger trigger1 = add.gameObject.AddComponent<EventTrigger>();
        trigger1.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entryDown1 = new EventTrigger.Entry();
        entryDown1.eventID = EventTriggerType.PointerDown;
        entryDown1.callback.AddListener(OnDown);
        trigger1.triggers.Add(entryDown1);

        //註冊button2的trigger
        EventTrigger trigger2 = de.gameObject.AddComponent<EventTrigger>();

        trigger2.triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entryDown2 = new EventTrigger.Entry();
        entryDown2.eventID = EventTriggerType.PointerDown;
        entryDown2.callback.AddListener(OnDown);
        trigger2.triggers.Add(entryDown2);

    }
    public void OnDown(BaseEventData arg0)
    {
        if(arg0.selectedObject.name==add.name)
        {
            a++;
            buyAmount.text = a + "";//轉字串顯示
            totalCost = a * cost;
            costText.text = totalCost + "";

        }
        if(arg0.selectedObject.name==de.name)
        {
            if (a > 0)//數量 <=0 時不可進行數量減少
            {
                a--;
            }
            buyAmount.text = a + "";//轉字串顯示
            totalCost = a * cost;
            costText.text = totalCost + "";
        }
        if(a==0)//沒買時變更背景顏色
        {
            back.color = new Color32(135, 161, 255, 255);
        }
        else//有買時變更背景顏色
        {
            back.color = new Color32(2, 43, 193, 255);
        }
        shop.AllCost();//每次按鍵都進行總成本重計
    }

    public int GetCost()
    {
        return totalCost;//回傳該物品總成本
    }

    public void Reo()//文字重新整理
    {
        buyAmount.text = a + "";//轉字串顯示
        totalCost = a * cost;
        costText.text = totalCost + "";
        if (ItemInfo.itemOwn[itemId] == 0)
        {
            iconBack.color = new Color32(90, 173, 255, 255);
        }
        else
        {
            iconBack.color = new Color32(32, 54, 77, 255);
        }
    }
}


