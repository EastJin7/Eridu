using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProloManager : MonoBehaviour {
    public ParticleSystem ray;
    public ParticleSystem ring;
    public ParticleSystem sparkles;
    public Image background;//灰黑背景
    public Image paper;//紙
    public Image enli;//恩利爾
    public Text storytext;//文字
    public Image enliti;//恩利爾與龍
    public Image enlitiwar;//恩利爾與龍有色
    public Image day;//天
    public Image sea;//地
    public Image kami;//神們
    public Image kamicr;//左山
    public Image kamicrea;//中山
    public Image kamicreate;//右山
    public Image kamicreated;//雲
    public Image human;//人
    public Image eridu;//埃里都
    public Image water;//大洪水
    public Image twogod;//兩個神
    public Image tree;//正常的樹
    public Image cha;//異變
    public Image chan;//異變2
    public Image chang;//異變3
    public Image change;//
    private LoadScene loadscene;
    public SoundManager sm;
    public AudioClip paperFlip;
    string[] story = { "在阿勃祖與提阿瑪特創世之後", "子神們對權勢的爭奪惹怒了提阿瑪特" ,"恩利爾先發制人，將其擊殺","他用暴風撐開提阿瑪特的喉嚨，以劍將其撕裂",
        "提阿瑪特的身體在死後形成了天空和大地","它的眼淚流向大地，形成了底格里斯和幼發拉底河",
    "諸位子神持續著創造的工作","他們創造了山、森林以及無數生命","但是，創造的工作實在太累了","於是，恩基和其子馬爾杜克提議：","「不如讓人類代替我們進行創造吧」",
    "於是，人類被製造出來，並被恩基賦予了智慧","恩基賦予人類君權，人類創造了埃里都的空前盛世",
    "但是，恩基對人類的偏愛惹怒了恩利爾","恩利爾認為人類不該擁有智慧與權力","祂召喚了大洪水淹沒了埃里都",
    "恩基命人製造了方舟，使人類躲過一劫","但恩基與恩利爾也因此而產生了分岐","另外一方面……","在大洪水過後，陸地上也產生了異變……"};

    // Use this for initialization
    void Start() {
        //background.transform.localScale = new Vector2(background.transform.localScale.x,0f);
        //初始化
        AchieveInfo.FirstStart();
        GameState.loginTime++;
        background.color = new Color32(255, 255, 255, 0);
        paper.transform.localScale = new Vector2(0f, paper.transform.localScale.y);//紙的大小一開始是0
        enli.color = new Color32(255, 255, 255, 0);
        enliti.color = new Color32(255, 255, 255, 0);
        enlitiwar.color = new Color32(255, 255, 255, 0);
        day.color = new Color32(255, 255, 255, 0);
        sea.color = new Color32(255, 255, 255, 0);
        kami.color = new Color32(255, 255, 255, 0);
        kamicr.color = new Color32(255, 255, 255, 0);
        kamicrea.color = new Color32(255, 255, 255, 0);
        kamicreate.color = new Color32(255, 255, 255, 0);
        kamicreated.color = new Color32(255, 255, 255, 0);
        human.color = new Color32(255, 255, 255, 0);
        eridu.color = new Color32(255, 255, 255, 0);
        water.color = new Color32(255, 255, 255, 0);
        twogod.color = new Color32(255, 255, 255, 0);
        tree.color = new Color32(255, 255, 255, 0);
        cha.color = new Color32(255, 255, 255, 0);
        chan.color = new Color32(255, 255, 255, 0);
        chang.color = new Color32(255, 255, 255, 0);
        change.color = new Color32(255, 255, 255, 0);
        storytext.color = new Color32(83, 44, 19, 0);
        storytext.text = story[0];
        //播放
        StartCoroutine(BackFlyIn());
        StartCoroutine(PaperFlyIn());
        loadscene = GameObject.FindObjectOfType<LoadScene>();
    }

    IEnumerator BackFlyIn()//背景漸入
    {
        yield return new WaitForSeconds(2f);//等寶石發完光
        StartCoroutine(FadeInImage(background));
        Destroy(ray);
        Destroy(ring);
        Destroy(sparkles);
        //while(background.transform.localScale.y<=1)
        //{
        //background.transform.localScale = new Vector2(background.transform.localScale.x,background.transform.localScale.y+0.1f);
        //yield return new WaitForSeconds(0.2f);
        //}
    }

    IEnumerator TextOut()//字出函式，wait必須小於四秒
    {
        byte texta = 255;
        while (texta > 0)
        {
            texta -= 5;
            storytext.color = new Color32(83, 44, 19, texta);//不透明度漸減
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator TextIn(int w)//字入
    {
        storytext.text = story[w];//換成下一行字
        byte texta = 0;
        while(texta < 255)
        {
            texta += 5;
            storytext.color = new Color32(83, 44, 19, texta);//不透明度漸增
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator FadeInImage(Image x)
    {
        Image fadein = x;
        byte a = 0;//有色漸入 圖1.圖2線搞漸出
        while (a < 255)
        {
            fadein.color = new Color32(255, 255, 255, a);
            a += 5;
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator FadeOutImage(Image y)
    {
        Image fadeout = y;
        byte a1 = 255;
        while(a1 > 0)
        {
            fadeout.color = new Color32(255, 255, 255, a1);
            a1 -= 5;
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator FadeOutImage(Image x,Image y)
    {
        Image fadeout1 = x;
        Image fadeout2 = y;
        byte a1 = 255;
        byte a2 = 255;
        while (a1 > 0)
        {
            fadeout1.color = new Color32(255, 255, 255, a1);
            fadeout2.color = new Color32(255, 255, 255, a2);
            a1 -= 5;a2 -= 5;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator PaperFlyIn()//紙張攤開
    {
        yield return new WaitForSeconds(3f);//等寶石發完光黑紙弄好
        sm.PlaySE(paperFlip);
        while (paper.transform.localScale.x <= 1)
        {
            paper.transform.localScale = new Vector2(paper.transform.localScale.x + 0.1f, paper.transform.localScale.y);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(TextIn(0));//字入 創世
        StartCoroutine(FadeInImage(enli));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(TextIn(1));//字入 惹怒
        StartCoroutine(FadeInImage(enliti));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(TextOut());//字出
        StartCoroutine(TextIn(2));//字入 先發制人
        StartCoroutine(FadeInImage(enlitiwar));
        StartCoroutine(FadeOutImage(enli, enliti));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//字出
        StartCoroutine(TextIn(3));//字入 撕裂
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//字出
        enlitiwar.color = new Color32(255, 255, 255, 0);//恩利爾戰爭消失
        StartCoroutine(PaperFlyLeft());//紙張飛走
    }

        IEnumerator PaperFlyLeft()//紙張飛出
    {
        sm.PlaySE(paperFlip);
        int x;
        for (x = 0; x >= -1200; x = x - 80)
        {//紙張位置從0~-1200，每X秒-50
            paper.rectTransform.anchoredPosition = new Vector2(x, paper.rectTransform.anchoredPosition.y);
            yield return new WaitForSeconds(0.02f);//X
        }
        yield return new WaitForSeconds(0.02f);//等上面執行完後執行下面
        int x2;
        for (x2=1200; x2>=0 ;x2=x2-80)
        {//紙張位置從1200~0，每0.0005秒-50
            paper.rectTransform.anchoredPosition = new Vector2(x2, paper.rectTransform.anchoredPosition.y);
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(FadeInImage(day));//天
        StartCoroutine(TextIn(4));//字入 提阿瑪特的屍體
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//字出
        StartCoroutine(TextIn(5));//字入 天地
        StartCoroutine(FadeInImage(sea));//海
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//字出
        yield return new WaitForSeconds(1f);
        day.color = new Color32(255, 255, 255, 0);//天消失
        sea.color = new Color32(255, 255, 255, 0);//地消失
        StartCoroutine(TextIn(6));//字入 子神創造
        StartCoroutine(FadeInImage(kami));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(FadeInImage(kamicr));
        StartCoroutine(TextIn(7));//字入 山天空森林
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeInImage(kamicrea));//子神創造中
        StartCoroutine(TextOut());//N秒後字出
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TextIn(8));//字入 但是太累
        StartCoroutine(FadeInImage(kamicreate));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(FadeInImage(kamicreated));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TextIn(9));//字入 提議
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(Human());
    }
    IEnumerator Human()
    {
        kami.color = new Color32(255, 255, 255, 0);
        kamicr.color = new Color32(255, 255, 255, 0);
        kamicrea.color = new Color32(255, 255, 255, 0);
        kamicreate.color = new Color32(255, 255, 255, 0);
        kamicreated.color = new Color32(255, 255, 255, 0);
        StartCoroutine(TextIn(10));//字入 人類代替
        StartCoroutine(FadeInImage(human));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(TextIn(11));//字入 人類智慧
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        human.color = new Color32(255, 255, 255, 0);
        StartCoroutine(FadeInImage(eridu));
        StartCoroutine(TextIn(12));//字入 埃里都
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(TextIn(13));//字入 恩利爾之怒
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(TextIn(14));//字入 他認為人類不該擁有智慧
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(FadeInImage(water));
        StartCoroutine(FadeOutImage(eridu));
        StartCoroutine(TextIn(15));//字入 大洪水
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        yield return new WaitForSeconds(2f);
        water.color = new Color32(255, 255, 255, 0);//洪水沒啦
        StartCoroutine(FadeInImage(twogod));
        StartCoroutine(TextIn(16));//字入 方舟
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(TextIn(17));//字入 兩神的分歧
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(3f);
        twogod.color = new Color32(255, 255, 255, 0);
        tree.color = new Color32(255, 255, 255, 255);
        StartCoroutine(TextIn(18));//字入 另一方面
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());//N秒後字出
        StartCoroutine(FadeInImage(chan));
        StartCoroutine(TextIn(19));//字入 異變
        yield return new WaitForSeconds(3f);
        StartCoroutine(TextOut());
        StartCoroutine(FadeInImage(chang));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeInImage(change));
        yield return new WaitForSeconds(2f);
        loadscene.LoadLevel("slimewar");
        yield return 0;
    }
}
