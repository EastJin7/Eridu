using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageUp : MonoBehaviour {
    private Vector3 target;//目標位置
    private Vector3 oScreen;//螢幕座標
    public Vector2 point;//GUI座標
    public float ContentWidth = 100;
    public float ContentHeight = 50;//文字高度和寬度
    public int damage;//傷害
    public float detime;//消失時間
    public GUISkin skin=null;

    void Start()
    {
        //GameObject gameobject = (GameObject)Instantiate(this.oObject);
        this.gameObject.SetActive(true);
        target = transform.position;//獲得目標座標
        oScreen = Camera.main.WorldToScreenPoint(target);//獲得螢幕座標
        point = new Vector2(oScreen.x, Screen.height - oScreen.y);//轉換出GUI座標
        detime = Time.time;
        //StartCoroutine(Depoint());//啟動自動銷毀
    }
    //    if(gameobject != null)
    //    {
    //        gameobject.SetActive(true);
    //        gameobject.transform.localScale = new Vector3(1f, 1f, 1f);

    //        Monster monter = GetComponent<Monster>();
    //        if (monter != null) DamageUp.DamagePoint(damage, this.oObject.transform.TransformPoint(Vector3.zero), mainCamera);
    //    }
    //}

    // Use this for initialization


    //IEnumerator Depoint()
    //{
    //    yield return new WaitForSeconds(detime);
    //    Destroy(this.gameObject);
    //}
    void Update ()
    {
        if (detime == 0)
        {
            return;
        }
        if (Time.time - detime<= 1.5f)
        {
            this.gameObject.SetActive(true);
            if (Time.time - detime<= 0.6f)
            { 
            this.transform.Translate(new Vector3(Time.deltaTime*-0.15f,Time.deltaTime * 1.3f,Time.deltaTime*-1.5f));//數字隨時間左上前飄
            }
            else
            {
                this.transform.Translate(new Vector3(Time.deltaTime * 0.2f,Time.deltaTime *-0.5f,Time.deltaTime*0.7f));//改成向右後下飄
            }
            target = transform.position;//不斷更新座標
            oScreen = Camera.main.WorldToScreenPoint(target);//不斷更新螢幕座標
            point = new Vector2(oScreen.x, Screen.height - oScreen.y);//不斷更新GUI座標
        }
        else
        {
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
        }
    }
    void OnGUI()
    {
        if (oScreen.z > 0)//確保螢幕照到目標
        {
            GUI.skin = skin;
            GUI.Label(new Rect(point.x-40f, point.y-10f, ContentWidth, ContentHeight), damage.ToString());
        }//繪製文字
    }

}
