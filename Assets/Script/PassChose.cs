using UnityEngine;
using System.Collections;

public class PassChose : MonoBehaviour {
    [SerializeField]
    private StoryManager story;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            story.PassChose();
            this.gameObject.SetActive(false);
        }
    }
}
