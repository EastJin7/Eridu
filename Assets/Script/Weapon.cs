using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public Transform target;
    private zerocontrol player;
    private Monster monster;
    public SoundManager sm;
    public AudioClip atSe;
    private BoxCollider2D boxCol;

    private AnimatorStateInfo animStateInfo;
    //private Animator anim;

    public int fcount;
    private float time;
    public bool atkright;
    private float enaTime;
    public float dmg;
    private const string atk1 = "attank";
    private const string atk2 = "attank2";
    private const string atk3 = "attank3";

    // Use this for initialization
    void Awake () {
        player = GameObject.FindObjectOfType<zerocontrol>();
        //anim = GetComponent<Animator>();
        transform.position = target.position;
        boxCol = this.GetComponent<BoxCollider2D>();
        if (atkright)
        {
            boxCol.offset = new Vector2(0.4f, 0.195f);
        }
        else
        {
            boxCol.offset = new Vector2(-0.4f, 0.195f);
        }
        if (player.animStateInfo.normalizedTime >= 0.9f)
        {
            boxCol.enabled = false;
        }
    }

    void Update()
    {
        player.animStateInfo = player.anim.GetCurrentAnimatorStateInfo(0);
        transform.position = target.position;
        atkright = player.facingRight;
        if (atkright)
        {
            boxCol.offset = new Vector2(0.4f,0.195f);
        }
        else
        {
            boxCol.offset = new Vector2(-0.4f, 0.195f);
        }
        if (player.animStateInfo.normalizedTime >= 0.9f)
        {
            boxCol.enabled = false;
        }
    }
    public void Enabled(int f)
    {
        fcount = f;
        switch(fcount)
        {
            case 1:
                enaTime = 0.35f;
                dmg = 10;
                break;
            case 2:
                enaTime = 0.2f;
                dmg = 10;
                break;
            case 3:
                enaTime = 0.25f;
                dmg = 20;
                break;
        }
        //if (fcount >= 1) { this.GetComponent<BoxCollider2D>().enabled = false; }//如果是第二第三段攻擊，先關閉第一段攻擊的碰撞器
        StartCoroutine((WeaponOn())); 
        return;
    }
    IEnumerator WeaponOn()
    {
        yield return new WaitForSeconds(enaTime);
        if ((player.animStateInfo.IsName(atk1)) || (player.animStateInfo.IsName(atk2)) || (player.animStateInfo.IsName(atk3)))
        {//此時仍在播放攻擊動畫時才會啟用碰撞器
            //monster.WeaponEnter(dmg, fcount, atkright);
            boxCol.enabled = true;//啟動或重啟碰撞器
            sm.PlaySE(atSe,3f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")//碰到目標是怪物時
        {
            StartCoroutine(closeCol());
            return;
        }
    }
    IEnumerator closeCol()
    {
        yield return new WaitForFixedUpdate();
        boxCol.enabled = false;
    }
}
