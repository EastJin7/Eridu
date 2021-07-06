using UnityEngine;
using System.Collections;

public class deadarea : MonoBehaviour
{
    private zerocontrol player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !GameState.gameover)//當碰撞到玩家時
        {
            player.Hurt(200f);//玩家扣血到死
            return;
        }
    }
}
