using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour {

    private Transform floor;
    //public string floorname;
    //public float toY = 2;
    //public float alpha = 0;
    float alpha = 0;
    public float toY = 1.5f; //移動的Y軸由編輯器指定，不指定的話為1.5f
    public float speed = 0.006f;
    private Transform target;
    private Transform original;

    void Start()
    {
        //floor = transform.Find(floorname);
    }
    void FixedUpdate()
    {
        //transform.position = new Vector3 (transform.position.x,Mathf.PingPong(Time.time * 0.8f, toY), transform.position.z);
        //寫成local的話不是鎖定座標的移動而是可以自己調位置
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(alpha, toY), transform.localPosition.z);
        alpha += speed;
        //此數值會是0~3
    }
    void OnCollisionEnter2D(Collision2D c)//碰撞進入時
    {
        if (c.gameObject.tag == "Player")//若對方是玩家
        {
            target = c.gameObject.transform;//目標位置為玩家
            target.SetParent(this.transform);//把目標設成子物件
        }
    }
    void OnCollisionStay2D(Collision2D c)//碰撞持續時
    {
        if (c.gameObject.tag == "Player")//若對方是玩家
        {
            target = c.gameObject.transform;//目標位置為玩家
            target.SetParent(this.transform);//把目標設成子物件
        }
    }

    void OnCollisionExit2D(Collision2D c)//碰撞離開時
    {
        if (c.gameObject.tag == "Player")
        {
            target = c.gameObject.transform;
            original = target.GetComponent<TransformState>().OriginalParent;
            target.SetParent(original);//恢復原本狀態
        }
    }
}
