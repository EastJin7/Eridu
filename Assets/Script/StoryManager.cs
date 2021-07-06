using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StoryManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject conPanel;
    public Image portrait;
    private Animator anim;
    public Image r1Port;
    public Image r2Port;
    public Image convf;
    public Text text;
    public Button sceneBtn;
    public Button hAtk;
    public Image hAtkF;
    [SerializeField]
    private GameObject crystal;
    [SerializeField]
    private GameObject crySprite;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private SetWall wall1;
    [SerializeField]
    private SetWall wall2;
    private zerocontrol player;
    private const string atk3 = "attank3";
    Image rightPort;
    public Image taskview;
    public Text task;
    int subId = 0;
    int idx = 0;
    bool nextString = false;//是否允許按螢幕後切換字
    bool press = false;//現在是否有按螢幕
    bool choise = false;
    bool Atkoff = false;

    bool story1 = false;
    bool story2 = false;
    bool talking = false;
    bool cho = false;
    bool passChose = false;
    bool boss = false;
    string [] story = { "","從異變之後，世界各地出現不平靜的現象","魔物也就是在這時候出現的…","吉榭爾！你到底有沒有在聽我說話！？" , "啊……？什麼？我、我剛才發呆了一下！" ,"你這白癡！才剛送妳寶石妳就得意忘形了！罰你揮劍一百次！！","嗚哇！不會吧？！","……","阿斯塔蒂，救命啊！魔物攻進來啦！","吉榭爾！該是你展現身手的時候了！"};
    string [] slime = { "嘿！看看上面！","幫幫我吧！人類！","我在屋頂上，快來找我！"};
    string[] slimetalk = { "人類，你來了！", "那尖刺是為了躲避其他人類追擊設計的，若傷到你就對不起啦！","……這個陷阱確實很有殺傷力。","抱歉啦！這是我的一點小歉意！","哇！傷口忽然不痛了！好神奇啊！","我們本來在北方的森林裡居住，過著幸福愉快的日子。但是有一天，其他族人忽然都失控了。","它們聚集起來，溫和的身體染上了毒性，可以腐蝕掉任何東西，還闖入村莊，四處破壞人類的房子。","人類，你願意幫助我找出異變的源頭嗎？", "…"};
    string[] pease = { "好啊，我也想知道怎麼會發生這種事。","感謝你，人類！","這是一個奇怪的人類給我的東西，他說如果有人答應了我的請求，就把這個給她。","用它來對付變異的魔物們，似乎就能讓它們恢復正常。"};
    string[] power = { "不要。我為什麼要幫助你？","……沒關係，我會繼續等下一個人類來的。", "希望你永遠不會後悔做了這個選擇。","."};
    string[] wait = { "……" };

    private Animator playerAnim;
    public Camera followCamera;
    public Camera storyCamera;
    public Transform specSlime;
    public GameObject conBtnPanel;
    int passTime;
    public SoundManager sm;
    [SerializeField]
    private AudioClip doorSe;
    [SerializeField]
    private AudioClip getSe;
    [SerializeField]
    private AudioClip noticeSe;

    void Start()
    {
        passTime = GameState.passtime0101;
        if (passTime >= 1) { GameState.drama = false; }
        anim = portrait.GetComponent<Animator>();
        taskview.enabled = false;
        task.enabled = false;
        GameState.gamepause = true;
        player = GameObject.FindObjectOfType<zerocontrol>();
        playerAnim = player.GetComponent<Animator>();
        r1Port.enabled = false;
        r2Port.enabled = false;
        if (GameState.clearLv == 0)
        {
            hAtk.enabled = false;
            hAtk.image.enabled = false;
            hAtkF.enabled = false;
        }
        conBtnPanel.SetActive(false);
        LeftProtOff();
        conPanel.SetActive(false);
        mainPanel.SetActive(false);
        door.SetActive(false);
        storyCamera.gameObject.SetActive(false);
        storyCamera.enabled = false;
        followCamera.enabled = true;
        story1 = false;//是否已經結束劇情1
        story2 = false;//是否已經結束劇情2
        talking = false;//與史萊姆對話
        StartCoroutine(StartStory());
        if (!GameState.drama && passTime >=1)
        {
            GameState.gamepause = false;
            mainPanel.SetActive(true);
            door.SetActive(true);
        }
    }

    void Update()
    {
        PressNext();//偵測是不是有按螢幕
        if (nextString == false)
        {
            sceneBtn.enabled = false;
            StopCoroutine(Print());
        }
        if (nextString == true)
        {
            sceneBtn.enabled = true;
        }
        if (!story1)
        {
            if (idx == 1)
            {
                RightProtOn(r1Port);
            }
            if (idx == 4)
            {
                anim.SetBool("Shack", true);
                LeftProtOn();
            }
            if (idx == 5)
            {
                anim.SetBool("Shack", false);
            }
            if (idx == 7)
            {
                LeftProtOff();
                RightProtOff();
                StoryOver();
                task.text = "按下攻擊按鍵，進行連續攻擊吧！";
                taskview.enabled = true;
                task.enabled = true;
                if (player.animStateInfo.IsName(atk3))
                {
                    Atkoff = true;
                }
                StartCoroutine(AtkJudge());
            }
            if (idx == 9)
            {
                RightProtOn(r1Port);
            }

            if (idx > 9)//對話到最後一句
            {
                StoryOver();//結束對話
                door.SetActive(true);//可以走了
                sm.PlaySE(doorSe);
                story1 = true;//已經過了劇情1
            }
        }
        if (story1 && !story2)
        {
            if (idx ==1)
            {
                RightProtOn(r2Port);
            }
            if (idx ==3)//對話到最後一句
            {
                nextString = false;
                StoryOver();//結束對話
                storyCamera.enabled = false;
                followCamera.enabled = true;
                story2 = true;
                taskview.enabled = true;
                task.enabled = true;
            }
        }
        if (story2 && talking)
        {
            if (idx==2)
            {
                LeftProtOn();
            }
            if(idx==3)
            {
                player.nowHp = 100;
            }
            if(idx==4)
            {
                anim.SetBool("Shack", true);
            }
            if(idx==5)
            {
                anim.SetBool("Shack", false);
            }
            if(idx==8)
            {
                talking = false;
                nextString = false;
                StoryOver();
                idx = 0;
            }
        }
        if (story2 && !talking && !cho)
        {
            story = wait;
            nextString = false;
            if (idx == 0)
            {
                StoryState();
                conBtnPanel.SetActive(true);
            }
        }
        if(cho)
        {
            if(idx==1)
            {
                RightProtOn(r2Port);
            }
            if(choise==true)//願意
            {
                if(idx==4)
                {
                    GameState.clearLv = 1;
                    hAtk.enabled = true;
                    hAtk.image.enabled = true;
                    hAtkF.enabled = true;
                    nextString = false;
                    StoryOver();
                    sm.PlaySE(getSe);
                    idx =0;
                }
            }
            if(choise==false)//不願意
            {
                if(idx==2)
                {
                    nextString = false;
                    StoryOver();//結束對話
                }
            }

        }
        //if (story2 && !talking)
        //{
        //    nextString = false;
        //    if (idx==0)
        //    {
        //        StoryState();
        //    }
        //}

        if(GameState.victory)
        {
            GameState.passtime0101 = passTime + 1;
            GameState.drama = false;
            GameState.noKilla = 8 - GameState.killa - GameState.cleara;
        }
    }

    IEnumerator StartStory()//本章開始
    {
            yield return new WaitForSeconds(2.5f);//等寶石發光結束
            crystal.SetActive(false);//水晶消失
            crySprite.SetActive(false);//水晶動畫消失
        if (GameState.drama && GameState.passtime0101 < 1)
        {
            idx += 1;
            text.text = story[idx];//文字更新
            nextString = true;//可下一句
            conPanel.SetActive(true);//對話窗出現
        }
    }

    IEnumerator AtkJudge()//砍一百下判斷
    {
        if (Atkoff==true)
        {
            Atkoff = false;
            idx = 8;
            yield return new WaitForSeconds(3f);
            StoryState();
            taskview.enabled = false;
            task.enabled = false;
        }
    }

    void StoryState()//開始故事時
    {
        GameState.gamepause = true;
        mainPanel.SetActive(false);//關閉所有UI
        conPanel.SetActive(true);//開啟對話UI
        ConOn();
        text.text = story[idx];
    }

    public void setPress(bool p)//獲取有無按畫面
    {
        press = p;
    }

    void PressNext()//按了之後下一句
    {
        if (nextString && press)//如果在可以按下就跳下一句的時候按下
        {
            idx = idx + 1;
            nextString = false;
            StartCoroutine(Print());
            press = false;
        }
        if (!nextString && press)
        {
            press = false;
        }
    }

    IEnumerator Print()
    {//印出的延時函式
        subId = 0;//目前打到的字
        text.text = "";
        while (true)
        {
            text.text += story[idx][subId];
            subId = Mathf.Clamp(subId, 0, story[idx].Length);//限制在這行第0位到這行的長度
            subId++;//打下一個字
            if (subId > story[idx].Length-1)//打完本句之後
            {
                nextString = true;
                break;
            }//跳出While避免debug視窗說超出range
            yield return new WaitForSeconds(0.05f);//每個字出現的延時
        }
    }

    void ConOn()//開啟對話窗
    {
        convf.enabled = true;
    }

    void ConOff()//關閉對話窗
    {
        convf.enabled = false;
    }

    void LeftProtOn()//開啟左邊立繪(主角)
    {
        portrait.enabled = true;
    }

    void RightProtOn(Image r)//開啟右邊立繪
    {
        rightPort = r;
        rightPort.enabled = true;
    }
    void LeftProtOff()//關閉左邊立繪(主角)
    {
        portrait.enabled = false;
    }
    void RightProtOff()//關閉右邊立繪
    {
        rightPort.enabled = false;
    }
    void StoryOver()//結束故事
    {
        ConOff();//關閉對話框
        RightProtOff();//關閉右立繪
        LeftProtOff();//關閉左立繪
        conPanel.SetActive(false);//關閉對話畫布
        GameState.gamepause = false;//結束暫停
        mainPanel.SetActive(true);//搖桿ui開啟
    }

    public void SlimeCall()//史萊姆叫你
    {
        if (GameState.drama && passTime < 1)
        {
            GameState.gamepause = true;
            mainPanel.SetActive(false);
            playerAnim.SetTrigger("notice");
            sm.PlaySE(noticeSe);
            StartCoroutine(SlimeAsk());
        }
    }
    IEnumerator SlimeAsk()
    {
        idx = 0;
        story = slime;
        yield return new WaitForSeconds(2f);
        StoryState();
        yield return new WaitForSeconds(1f);
        storyCamera.gameObject.SetActive(true);
        storyCamera.enabled = true;
        followCamera.enabled = false;
        nextString = true;
        task.text = "直接前進，或是上屋頂與史萊姆對話";
    }
    public void SlimeTalk()//與史萊姆對話
    {
        if (GameState.drama && passTime < 1)
        {
            taskview.enabled = false;
            task.enabled = false;
            story = slimetalk;
            idx = 0;
            talking = true;
            StoryState();
            RightProtOn(r2Port);
            nextString = true;
        }
    }

    public void SlimeChose(bool b)
    {
        if (GameState.drama && passTime < 1)
        {
            choise = b;
            if (choise)
            {
                conBtnPanel.SetActive(false);
                story = pease;
                if (passTime == 0)
                {
                    GameState.powerline = false;
                }
            }
            else
            {
                conBtnPanel.SetActive(false);
                story = power;
                if (passTime == 0)
                {
                    GameState.powerline = true;
                }
            }
            nextString = false;
            StartCoroutine(AfterChose());
            cho = true;
        }
    }
    IEnumerator AfterChose()
    {
        idx = 0;
        yield return new WaitForSeconds(0.1f);
        StoryState();
        LeftProtOn();
        nextString = true;
    }
    public void PassChose()
    {
        wall1.Set();
    }
    public void Boss()
    {
        wall2.Set();
    }
}
