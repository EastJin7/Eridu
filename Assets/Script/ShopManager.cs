using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    [SerializeField]
    private ShopBuy[] buy;//所有物品元素
    [SerializeField]
    private ItemView[] item;
    [SerializeField]
    private Text coinCost;//總消耗金錢顯示
    [SerializeField]
    private Text cryCost;//總消耗水晶顯示
    [SerializeField]
    private Text friCost;//總消耗友點顯示
//計算用
    [SerializeField]
    private MenuInfo playerInfo;//玩家財產
    [SerializeField]
    private SavePlayerPrefs save;
    [SerializeField]
    private Text con;//對話
    //變數
    int allCoin = 0;
    int allCry = 0;
    int allFri = 0;
    int i;
    //對話事件跟節省打字用
    int hCoin;
    int hCry;
    int hFri;
    int noMoney;
    [SerializeField]
    private LoadScene loadScene; 

    void Start ()
    {
        //總花費初始化
        coinCost.text = "0";
        cryCost.text = "0";
        friCost.text = "0";
        hCoin = GameState.allCoins;
        hCry = GameState.crystal;
        hFri = GameState.friendP;
	}

    public void AllCost()//計算總成本的方法(每次按鍵或購買時呼叫)
    {
        allCoin = 0;
        allCry = 0;
        allFri = 0;
        for(i=0; i<buy.Length; i++)//跑過所有陣列
        {
            if(buy[i].type==0)//金錢類
            {
                allCoin += buy[i].GetCost();
            }
            if(buy[i].type==1)//水晶類
            {
                allCry += buy[i].GetCost();
            }
            if(buy[i].type==2)//友點類
            {
                allFri += buy[i].GetCost();
            }
        }
        viewCost();
        if (allCoin > 100) { con.text = "是不是應該算你便宜一點？"; }
        if (allCry > 100) { con.text = "錢不夠的話，我可是會趕人的。"; }
    }
    public void Cancel()//清空購物車
    {
        for(i=0;i<buy.Length;i++)
        {
            buy[i].a = 0;
            buy[i].Reo();
        }
        allCoin = 0;
        allCry = 0;
        allFri = 0;
        viewCost();
    }
    void viewCost()
    {
        coinCost.text = allCoin + "";
        cryCost.text = allCry + "";
        friCost.text = allFri + "";
    }
    public void Buy()
    {
        if((hCoin < allCoin)||(hCry<allCry)||(hFri<allFri))
        {
            noMoney++;
            con.text = "沒帶夠錢，就別站在這裡浪費我的時間";
            if(noMoney==3)
            {
                con.text = "我是商人，不是聖人";
            }
            if(noMoney==4)
            {
                con.text = "我是真的會趕人的";
            }
            if(noMoney==5)
            {
                con.text = "……（不耐）";
            }
            if(noMoney==6)
            {
                con.text = "你是故意的吧？別挑戰我的耐性";
            }
            if(noMoney==7)
            {
                con.text = "……";
            }
            if(noMoney>=8)
            {
                loadScene.LoadLevel("MainMENU");
            }
        }
        else
        {
            for (i = 0; i < buy.Length; i++)
            {
                if (buy[i].a > 0)
                {
                    ItemInfo.itemOwn[buy[i].itemId] += buy[i].a;
                    Debug.Log(ItemInfo.itemName[buy[i].itemId] + "數量+" + buy[i].a);
                    //先獲取該物品的itemID，使該ID的物品擁有數+=購買數量
                    GameState.shopBuyTime++;
                }
            }
            GameState.allCoins -= allCoin;
            GameState.crystal -= allCry;
            GameState.friendP -= allFri;
            GameState.shopCostCry += allCry;
            playerInfo.Reo();
            Cancel();
            save.Save();
            if(GameState.allCoins - hCoin > 50) { con.text = "……似乎挺有錢的呢"; }
            hCoin = GameState.allCoins;
            hCry = GameState.crystal;
            hFri = GameState.friendP;
            ReoItemAmount();
        }
    }
    public void ReoItemAmount()
    {
        for(i=0;i<item.Length;i++)
        {
            item[i].Reo();
        }
    }
}
