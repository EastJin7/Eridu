using UnityEngine;
using System.Collections;

public class NPCSlime : MonoBehaviour {
    public StoryManager story;
    public zerocontrol player;
    public Collider2D trigger;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.talkOpen == true)
        {
            player.talkOpen = false;
            player.NPCTalk(false);
            story.SlimeTalk();
            trigger.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            player.NPCTalk(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            player.NPCTalk(false);
        }
    }
    

}
