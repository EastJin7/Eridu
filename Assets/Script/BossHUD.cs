using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHUD : MonoBehaviour
{
    public Monster mon;
    public float hp, fullhp;
    public int fixX;

    // Update is called once per frame
    void Update()
    {
        hp = mon.myHp;
        fullhp = mon.fullHp;
        this.transform.localPosition = new Vector3((-fixX + fixX * (hp / fullhp)), 0.0f, 0.0f);
    }
    public void Coruscate()
    {
        this.GetComponent<Image>().color = new Color32(255, 0, 0, 255); //亮
        StartCoroutine(StopCoruscate());
    }
    IEnumerator StopCoruscate()
    {
        //        yield return new WaitForSeconds(1.0f);//無敵時間
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Image>().color = new Color32(184, 0, 0, 255);//暗
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Image>().color = new Color32(255, 0, 0, 255);//亮
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Image>().color = new Color32(184, 0, 0, 255);//暗
    }
    //    184 0 0 255
}
