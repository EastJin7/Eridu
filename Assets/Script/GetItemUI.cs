using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetItemUI : MonoBehaviour {
    public GameObject getPanel;
    [SerializeField]
    private SoundManager sm;
    [SerializeField]
    private AudioClip get;
    public Text item;
    float now;
    [SerializeField]
    private MenuInfo info;
    private Scene scene;


    void Awake ()
    {
        getPanel.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }
    public void GetItem(string itemName)
    {
        gameObject.transform.localPosition = new Vector3(545, -50f);
        item.text = itemName;
        getPanel.SetActive(true);
        sm.PlaySE(get, 0.5f);
        StartCoroutine(InAndOut());
        //now = Time.time;
        if (scene.name == "MainMENU")
        {
            ReoCry();
        }
    }
    //void FixedUpdate()
    //{
    //    if(Time.time - now<=1f)
    //    {
    //        gameObject.transform.localPosition += new Vector3(-11f, 0, 0);
    //    }
    //    if(Time.time - now >=3f && Time.time - now <=5f)
    //    {
    //        gameObject.transform.localPosition += new Vector3(-11f, 0, 0);
    //    }
    //    if(Time.time - now >5f)
    //    {
    //        getPanel.SetActive(false);
    //        gameObject.transform.localPosition = new Vector3(545, 134f);
    //    }
    //}
    IEnumerator InAndOut()
    {
        int x = 545;
        while (x>0)
        {
            x-=15;
            gameObject.transform.localPosition = new Vector3(x, 10f);//134f
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);
        while(x>-878)
        {
            x-=15;
            gameObject.transform.localPosition = new Vector3(x, 10f);
            yield return new WaitForSeconds(0.02f);
        }
    }
    void ReoCry()
    {
        info.Reo();
    }
}
