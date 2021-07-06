using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class LoadTips : MonoBehaviour {
    private string[] _tips;//宣告區域陣列
    public Text _tipsText;//宣告公共變數Text格式的_tipsText
    private float lastTime = 0.0f;
    private const int waitTime = 2;//刷新等待時間
    private string filePath;

    void Start()//此物件啟用時
    {
        Read();
        _tipsText = GetComponent<Text>();
        if (_tips != null && _tips.Length > 0)//當_tips不為空且長度>0時
        {
            int idx = Random.Range(0, _tips.Length - 1);//亂數產生索引值0~陣列長度-1
            _tipsText.text = _tips[idx];//變更文字
        }
    }

    void Update()
    {
        if (_tips == null || _tips.Length <= 0)//_tips陣列是空值或長度為0時
            Debug.Log("讀不到!!");
            return;//中止

        if (Time.time - lastTime >= waitTime)//當計時器跑了waitTime秒
        {
            lastTime = Time.time;//時間更新
            int idx = Random.Range(0, _tips.Length - 1);//產生新亂數
            _tipsText.text = _tips[idx];//刷新Tips內容
        }
    }

    void Read()
    {
        int length;
        length = TipsContent.content.Length;
        _tips = new string[length];
        int i = 0;
        while (i < length)
        {
            _tips = TipsContent.content;
            i++;
        }
    }

    //void LoadJson()
    //{
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    filePath = "jar:file://" + Application.dataPath + "!/assets/" + "/Tips.json";
        //}
        //if (Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        //    filePath = Application.dataPath + "/Raw/" + "Tips.json";
        //}
        //else
        //{
        //    filePath = Application.dataPath + "/StreamingAssets/" + "Tips.json";
        //}

    //    //else
    //    //{
    //    //    filePath = Application.dataPath + "/Resources/Json/Tips.json";
    //    //}
    //    if (!File.Exists(filePath))
    //    {
    //        Debug.Log("找不到json！");
    //    }
    //    StreamReader sr = new StreamReader(filePath);
    //    int i = 0;
    //    _tips = new string[File.ReadAllLines(filePath).Length];
    //    string line;
    //     while((line=sr.ReadLine())!=null)
    //        {
    //            _tips[i] = line;
    //            i++;
    //        }
    //}


    //void LoadXml()//方法讀取XML
    //{
    //        filePath = Application.dataPath + @"/Resources/Xml/Tips.xml";//OS保存路徑
        
    //            if (File.Exists(filePath))//如果檔案存在該路徑下
    //        {
    //            XmlDocument xmlDoc = new XmlDocument();//將XML實例化
    //            xmlDoc.Load(filePath);//讀取檔案位置/Resources/Xml/Tips.xml
    //            XmlNodeList node = xmlDoc.SelectSingleNode("plist").ChildNodes;//在plist處創建子結點
    //            foreach (XmlElement nodeList in node)
    //            {
    //                foreach (XmlElement xe in nodeList)
    //                {
    //                    if (xe.Name == "array")//當元素名稱為"array"時
    //                    {
    //                        int i = 0;
    //                        _tips = new string[xe.ChildNodes.Count];
    //                        foreach (XmlElement xe1 in xe.ChildNodes)
    //                        {
    //                            //                          Debug.Log(xe1.InnerText);  
    //                            _tips[i] = xe1.InnerText;
    //                            i++;
    //                        }
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
}
