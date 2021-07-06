using UnityEngine;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    private string UI_Prefabs = "Prefabs/UI/";//路徑
    public GameObject m_Canvas;
    public Dictionary<string, GameObject> m_PanelList = new Dictionary<string, GameObject>();
    //用來存放介面，開啟時就會把開啟的介面名稱存入

    private bool CheckCanvasRootIsNull()//判斷Canvas是否null
    {
        if (m_Canvas == null)
        {
            Debug.LogError("m_Canvas is Null, Please in your Canvas add UIRootHandler.cs");//回傳錯誤訊息
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsPanelLive(string name)//判斷介面是否開啟
    {
        return m_PanelList.ContainsKey(name);//直接從Dictionary存放的顯示介面名稱中取出
    }
    public GameObject ShowPanel(string name)//顯示介面
    {
        if (CheckCanvasRootIsNull())//如果畫布為空
            return null;//開啟失敗

        if (IsPanelLive(name))//如果UI已經開啟，回傳錯誤訊息
        {
            Debug.LogErrorFormat("[{0}] is Showing, if you want to show, please close first!!", name);
            return null;//開啟失敗
        }

        GameObject loadGo = Utility.AssetRelate.ResourcesLoadCheckNull<GameObject>(UI_Prefabs + name);//從路徑讀取遊戲物件
        if (loadGo == null)//如果讀取不到
            return null;//開啟失敗


        GameObject panel = Utility.GameObjectRelate.InstantiateGameObject(m_Canvas, loadGo);//實例化放入Canvas下
        panel.name = name;//panel名稱改成跟介面名稱一樣


        m_PanelList.Add(name, panel);//把名稱與panel放入交給Dictionary控管


        return panel;
    }

    public void TogglePanel(string name, bool isOn)//顯示或隱藏介面
    {
        if (IsPanelLive(name))//判斷是否已經開啟
        {
            if (m_PanelList[name] != null)//已經開啟
                m_PanelList[name].SetActive(isOn);//進行開啟或關閉動作
        }
        else//找不到介面或不是開啟狀態
        {
            Debug.LogErrorFormat("TogglePanel [{0}] not found.", name);
        }
    }

    public void ClosePanel(string name)//關閉介面
    {
        if (IsPanelLive(name))//判斷是否開啟
        {
            if (m_PanelList[name] != null)//已經開啟
                Object.Destroy(m_PanelList[name]);//關閉

            m_PanelList.Remove(name);//從Dictionary中移除
        }
        else//找不到介面或不是開啟狀態
        {
            Debug.LogErrorFormat("ClosePanel [{0}] not found.", name);
        }
    }

    public void CloseAllPanel()//關閉所有介面
    {
        foreach (KeyValuePair<string, GameObject> item in m_PanelList)
        {
            if (item.Value != null)//判斷GameObject是否為空
                Object.Destroy(item.Value);//不為空則移除
        }

        m_PanelList.Clear();//清除Dictionary
    }

    public Vector2 GetCanvasSize()//取得Canvas的size
    {
        if (CheckCanvasRootIsNull())//判斷canvas是否為空
            return Vector2.one * -1;//回傳-1,-1

        RectTransform trans = m_Canvas.transform as RectTransform;//否則取出其RectTransform

        return trans.sizeDelta;//回傳size
    }
}
