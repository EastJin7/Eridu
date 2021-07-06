using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    private zerocontrol player;
    private bool enter = false;
    private bool exit = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            enter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            exit = true;
        }
    }
    public bool IsEnter()
    {
        return enter;
    }
    public bool IsExit()
    {
        return exit;
    }
}
