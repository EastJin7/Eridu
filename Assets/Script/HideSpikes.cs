using UnityEngine;
using System.Collections;
using System;

public class HideSpikes : MonoBehaviour {
	private zerocontrol player;
    public GameObject hidespike;
    float lastTime = 0.0f;
    float waitTime = 3f;//出現間隔
    bool hide = true;

    void Start () {
        player = GameObject.FindObjectOfType<zerocontrol>();
        hidespike.SetActive(false);
        hide = true;
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")//碰到觸發陷阱點的是玩家時
		{
            hidespike.SetActive(true);
        }
	}
    void Update()
    {
        if (Time.time - lastTime >= waitTime)
        {
            if (hide == true)
            {
                hide = false;
                waitTime = 1f;
                lastTime = Time.time;
                hidespike.transform.localPosition = new Vector3(hidespike.transform.localPosition.x, hidespike.transform.localPosition.y + 1f, hidespike.transform.localPosition.z);
            }
            else
            {
                hide = true;
                waitTime = 3f;
                lastTime = Time.time;
                hidespike.transform.localPosition = new Vector3(hidespike.transform.localPosition.x, hidespike.transform.localPosition.y - 1f, hidespike.transform.localPosition.z);
            }
        }
    }
}
