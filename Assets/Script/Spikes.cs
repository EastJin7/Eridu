using UnityEngine;
using System.Collections;
using System;

public class Spikes : MonoBehaviour {
    private zerocontrol player;

	void Start () {
        player = GameObject.FindObjectOfType<zerocontrol>();

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到陷阱的是玩家時
        {
            player.Hurt(40f);//讓玩家執行受傷程式
//            other.SendMessage("Hurt", 40);
        }
    }
}
