using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuTalk : MonoBehaviour {

    private string[] talk;
    private int idx;
    int subId = 0;
    Text text;
    private float lastTime = 0.0f;//最後時間
    private const int waitTime = 8;//刷新等待時間

    // Use this for initialization
    void Awake () {

        text = GetComponent<Text>();//找到Text
        GetTalk();//獲取talk內容
        if (talk != null && talk.Length > 0)//當talk不為空且長度>0時
        {
            idx = Random.Range(0, talk.Length - 1);//亂數產生索引值0~陣列長度-1
        }
        StartCoroutine(Print());//延時執行印出函式
    }

    void Update()
    {
        if (Time.time - lastTime >= waitTime)//當計時器跑了waitTime秒
        {
            lastTime = Time.time;//時間更新
            int oldid = idx;//紀錄現在的tip數字
            idx = Random.Range(0, talk.Length - 1);//產生新亂數
            while(oldid == idx)//如果重複了
            {
                idx = Random.Range(0, talk.Length - 1);//產生新亂數
            }
            StartCoroutine(Print());//延時執行印出函式
        }
    }
	
	IEnumerator Print () {//印出的延時函式
        subId = 0;//目前打到的字
        text.text = "";
        while (true)
        {
            text.text += talk[idx][subId];
            subId = Mathf.Clamp(subId, 0, talk[idx].Length);//限制在這行第0位到這行的長度
            subId++;//打下一個字
            if (subId > talk[idx].Length - 1)//打完本句之後
            { break; }//跳出While避免debug視窗說超出range
            yield return new WaitForSeconds(0.1f);//每個字出現的延時



        }

	}
    void GetTalk()
    {
        int length;
        length = TipsContent.gesellSay.Length;
        talk = new string[length];
        int i = 0;
        while (i < length)
        {
            talk = TipsContent.gesellSay;
            i++;
        }

    }
}
