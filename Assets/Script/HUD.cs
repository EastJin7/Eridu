using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public zerocontrol player;
    public float hp, fullhp;
    public int fixX;

    // Use this for initialization
    void Start()
    {
        //        player = GameObject.FindGameObjectWithTag("Player").GetComponent<zerocontrol>();
        player = GameObject.FindObjectOfType<zerocontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.nowHp;
        fullhp = player.maxHp;
        this.transform.localPosition = new Vector3((-fixX+fixX*(hp / fullhp)), 0.0f, 0.0f);
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
