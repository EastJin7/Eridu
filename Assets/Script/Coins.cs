using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {
    private PlayerState playerState;
    float lastTime;
    float creaTime;
    int roTimes = 0;
    int downTime = 0;
    private ObjectPool coinsPool;

    // Use this for initialization
    void Awake()
    {
        playerState = GameObject.FindObjectOfType<PlayerState>();
        coinsPool = GameObject.Find("coinsPool").GetComponent<ObjectPool>();
    }
    void OnEnable() 
    {
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.time - lastTime < 1f)
        {
            transform.Translate(0f, 0.8f * Time.deltaTime, 0f);
        }
        StartCoroutine(Rota());
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")//碰到的是玩家時
        {
            playerState.CoinPlus(10);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
            transform.Translate(0f, 25 * Time.deltaTime, 0f);
            StartCoroutine(Recovery());
        }
    }
    IEnumerator Rota()
    {
        yield return new WaitForSeconds(0.1f);
        if (roTimes <= 19)
        {
            transform.Rotate(Vector3.up * 4);
            roTimes++;
        }
        if(roTimes >19)
        {
            transform.Rotate(Vector3.down * 4);
            downTime++;
            if (downTime >19)
            {
                roTimes = 0;
                downTime = 0;
            }
        }
    }
    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(0.6f);
        coinsPool.Recovery(this.gameObject);
    }
}
