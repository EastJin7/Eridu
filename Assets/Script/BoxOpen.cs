using UnityEngine;
using System.Collections;

public class BoxOpen : MonoBehaviour {
    private zerocontrol player;
    public Animator anim;
    public GameObject boxlight;
    public ObjectPool pool;
    public SoundManager sm;
    public AudioClip opSe;
    private Vector3 pos;
    bool isOpened=false;

    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        anim = this.GetComponent<Animator>();
        boxlight.transform.localScale = new Vector3(0,0,0);
        pos = transform.position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            if (!isOpened)
            {
                sm.PlaySE(opSe);
                anim.SetBool("open", true);
                pool.ReUse(pos, Quaternion.identity);
                pool.ReUse(pos, Quaternion.identity);
            }
            isOpened = true;
        }
    }

}
