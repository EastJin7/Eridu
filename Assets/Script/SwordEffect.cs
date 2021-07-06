using UnityEngine;
using System.Collections;

public class SwordEffect : MonoBehaviour {
    public zerocontrol player;
    public bool atkright;
    private ObjectPool swordPool;

    void Awake()
    {
        swordPool = GameObject.Find("swordPool").GetComponent<ObjectPool>();
    }
    void OnEnable()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        atkright = player.facingRight;
        if (!atkright)
        {
            transform.localScale = new Vector3(1, 1);
        }
        if(atkright)
        {
            transform.localScale = new Vector3(-1, 1);
        }
        StartCoroutine(Recovery());
    }
	
	void FixedUpdate() {
        if (atkright)
        {
            this.gameObject.transform.position  += new Vector3(0.1f,0);
        }
        else
        {
            this.gameObject.transform.position += new Vector3(-0.1f,0);
        }
    }
    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 80);
        yield return new WaitForSeconds(0.5f);
        swordPool.Recovery(this.gameObject);
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Monster")//碰到目標是怪物且還沒被銷毀(還沒死亡)時
    //    {
    //        return;
    //    }
    //}
}
