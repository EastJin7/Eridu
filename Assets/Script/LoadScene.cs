using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    private string levelToLoad;//轉移過去的螢幕改成不可在編輯畫面上指定
    public float Localx;//Loading文字的起始位置
    public float Localscale;//Loading文字的position比例轉換
    public Image background;
    public Image loadImage;//Loading條
    public Text loadText;//Loading的%數
    public Text loadTips;//Loading的Tips
    private float progressline;//用於印出進度條
    private int displayprogress;//表示用進度，用漸進方式表達progress
    private int updateprogress;//真正的進度
    [SerializeField]
    private SavePlayerPrefs save;

    void Awake()
    {
        Application.targetFrameRate = 35;
        Debug.Log("SceneName : "+SceneManager.GetActiveScene().name);
        background.enabled = false;
        loadImage.enabled = false;
        loadText.enabled = false;
        loadTips.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void LoadLevel(string tolevel)
    {
        save.Save();//每次進行Loading都進行一次儲存
        levelToLoad = tolevel;
        StartCoroutine(DisplayLoadingScreen(levelToLoad));
        //SceneManager.LoadScene("01");//,LoadSceneMode.Additive添加畫面到當前場景
        return;
    }
    IEnumerator DisplayLoadingScreen(string sceneName)//延時函式，變數為收到的string
    {
        background.enabled = true;
        loadImage.enabled = true;
        loadText.enabled = true;
        loadTips.enabled = true;
        AsyncOperation async = SceneManager.LoadSceneAsync(levelToLoad);//異步加載到levelToLoad的String
        async.allowSceneActivation = false;//現在還不允許轉換場景
        while (async.progress < 0.9f)//在90%前執行以下函式
        {
            updateprogress = (int)async.progress * 100; //真正進度原為0.x，*100轉換成%數
            while (displayprogress < updateprogress)//當表示用進度尚未跑到真正進度時
            {
                PrintLoading();//印出Loading進度
                yield return new WaitForEndOfFrame();//等待幀刷新
            }
        }
            updateprogress = 100;//為了避免卡在90%，在進度>90%之後馬上更新進度到100%
        while (displayprogress < updateprogress)
            {
                PrintLoading();//印出Loading進度
            yield return new WaitForEndOfFrame();//等待幀刷新
        }
        async.allowSceneActivation = true;//跑到100%之後允許場景轉換
        yield return null;//場景轉換結束
    }

    void PrintLoading()//展示Loading進度
    {
        ++displayprogress;//漸進式表現進度
        progressline = displayprogress;//由於調整圖片大小時需要浮點數計算，所以把值傳到浮點數變數progressline
        loadText.text = displayprogress.ToString() + "%";//把進度數字變為"x%"
        loadImage.transform.localScale = new Vector2(progressline / 100, loadImage.transform.localScale.y);//進度條大小隨進度變更，由於進度*100所以這裡要/100
        loadText.transform.localPosition = new Vector2(Localx + progressline * Localscale, loadText.transform.localPosition.y);//轉換比例由編輯介面指定
        //不知道比例就調好用Debug.Log(loadText.transform.localPosition.x);紀錄起始跟結尾，scale是如何才能100%到結尾
    }
    //    if(async.isDone)
    //    {
    //            Destroy(this);
    //    }
    //}
}
