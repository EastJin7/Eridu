using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    public Texture BackImage = null;

    private AsyncOperation async = null;
    // Use this for initialization
    void Start () {
        //此物體在下一個場景中不會被銷毀

        DontDestroyOnLoad(this);
        //開始加載場景

        StartCoroutine("LoadScene");
    }
    IEnumerator LoadScene()

    {
        async = SceneManager.LoadSceneAsync("Next");

        yield return async;

        Debug.Log("Complete!");

    }
    void OnGUI()

    {
        //切換場景中的背景
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BackImage);
        //加載過程中顯示進度
        if (async != null && async.isDone == false)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 48;
            GUI.Label(new Rect(0, 200, Screen.width, 20), async.progress.ToString("F2"), style);
        }
        //在加載結束後，彈出是否下個場景，模擬手遊中"觸摸任意位置進入遊戲"
        if (async != null && async.isDone == true)
        {
            if (GUI.Button(new Rect(100, 100, 100, 100), new GUIContent("跳起進入下一個場景")))
            {
                Destroy(this);
            }
        }
        //LoadingObj物體被設置為DontDestroyOnLoad(this)，也就是在新的場景中不銷毀，即使在新場景加載後也會占滿全屏的背景仍然存在，直到物體被銷毀
        //LoadingObj物體銷毀的方式有兩種，一種是手動方式，就像下面代碼中使用的，點擊Middle場景中的按鈕銷毀自己 ，另外一種自動方式是在新場景（Next場景）中的MonoBehavior: OnLevelWasLoaded()函數中銷毀該物體。
        //如下
        //    void OnLevelWasLoaded(int level)
        //{
        //    GameObject obj = GameObject.Find("LoadingObj");
        //    if (obj != null)
        //    {
        //        GameObject.Destroy(obj);
        //    }




        }
    }
