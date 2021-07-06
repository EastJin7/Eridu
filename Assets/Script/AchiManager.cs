using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchiManager : MonoBehaviour {
    //放在各場景的成就小視窗進行判斷，當目標達成時啟用成就達成UI
    public GameObject achiPanel;
    public Text achiText;
    public SoundManager sm;
    public AudioClip gotSe;
	void Start ()
    {
        //AchieveInfo.FirstStart();
        achiPanel.SetActive(false);
    }

    void Update()
    {
        if (GameState.allSword >= 100) { ViewAchi(0); }
        if(GameState.allTryCle >= 100) { ViewAchi(5); }
        if(GameState.allNoKillA >= 20) { ViewAchi(10); }
        if (GameState.allKillA >= 20) { ViewAchi(20); }
        if (GameState.allClearA >= 20) { ViewAchi(30); }
        if (GameState.powerline) { ViewAchi(40); }
        if(GameState.clearLv >= 1) { ViewAchi(41); }
        if (GameState.passtime0102 >= 1) { ViewAchi(42); }

        if (GameState.loginTime >= 20) { ViewAchi(60); }
        if (GameState.allGameTime >= 3600) { ViewAchi(65); }
        if (GameState.allDead >= 20) { ViewAchi(70); }
        if(GameState.allCoins >= 500) { ViewAchi(80); }
        if(GameState.friendP >= 100) { ViewAchi(85); }
        if (GameState.crystal >= 50) { ViewAchi(90); }

        if (GameState.shopBuyTime >= 30) { ViewAchi(95); }
        if(GameState.shopCostCry >= 100) { ViewAchi(98); }

        if (GameState.slimeKill >= 10) { ViewAchi(110); }
        if(GameState.slimeKill >= 30) { ViewAchi(111); }
        if (GameState.batKill >= 10) { ViewAchi(115); }
        if(GameState.wolfKill >= 10) { ViewAchi(120); }

        if (GameState.passtime0101 >= 1) { ViewAchi(160); }
        if (GameState.passtime0101 >= 10) { ViewAchi(161); }


    }

    void ViewAchi(int id)
    {
        if (AchieveInfo.achiBoun[id]==false)
        {
            AchieveInfo.achiBoun[id] = true;
            StartCoroutine(Boun(id));
        }
    }
    IEnumerator Boun(int id)
    {
        yield return new WaitForSeconds(0.5f);
        achiText.text = AchieveInfo.achiName[id];
        achiPanel.SetActive(true);
        achiPanel.transform.localPosition = new Vector3(-765, 60);
        yield return new WaitForSeconds(0.05f);
        achiPanel.transform.localPosition = new Vector3(-690, 60);
        yield return new WaitForSeconds(0.05f);
        achiPanel.transform.localPosition = new Vector3(-630, 60);
        yield return new WaitForSeconds(0.05f);
        achiPanel.transform.localPosition = new Vector3(-580, 60);
        yield return new WaitForSeconds(0.05f);
        achiPanel.transform.localPosition = new Vector3(-515, 60);
        yield return new WaitForSeconds(2.5f);//停留
        sm.PlaySE(gotSe);
        achiPanel.transform.localPosition = new Vector3(-580, 60);
        yield return new WaitForSeconds(0.08f);
        achiPanel.transform.localPosition = new Vector3(-630, 60);
        yield return new WaitForSeconds(0.08f);
        achiPanel.transform.localPosition = new Vector3(-690, 60);
        yield return new WaitForSeconds(0.08f);
        achiPanel.transform.localPosition = new Vector3(-765, 60);


    }
}
