using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossPoint : MonoBehaviour {
    [SerializeField]
    private StoryManager story;
    [SerializeField]
    private GameObject BossHUD;

    void Start()
    {
        BossHUD.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            story.Boss();
            this.gameObject.SetActive(false);
            BossHUD.SetActive(true);
        }
    }
}
