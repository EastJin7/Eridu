using UnityEngine;
using System.Collections;

public class SlimeSayPoint : MonoBehaviour {
    public StoryManager story;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            story.SlimeCall();
            this.gameObject.SetActive(false);
        }
    }

}
