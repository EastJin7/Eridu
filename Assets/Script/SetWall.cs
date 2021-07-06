using UnityEngine;
using System.Collections;

public class SetWall : MonoBehaviour {

    void Start()
    {
        this.gameObject.SetActive(false);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Set()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<BoxCollider2D>().enabled = true;
        Resources.UnloadUnusedAssets();//在關卡中卸載未使用的資源
    }
}
